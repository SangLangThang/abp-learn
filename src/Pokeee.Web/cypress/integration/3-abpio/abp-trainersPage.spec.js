/// <reference types="cypress" />

let lengthMenuItem = 9;
let column = 3;
let nameTest = 'UserTest' + new Date().getTime();
let nameEdit = `${nameTest}Test`
let urlAvatar = 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/';
let urlGet = '/api/app/trainers?filterText=&name=&pokemonId=&sorting=trainer.name%20asc&skipCount=0&maxResultCount=10'
let selectedAvatar = 3;
let delay =300
describe('Trainers Page', () => {
    beforeEach(() => {
        cy.visit('https://localhost:44316/Trainers')
        cy.get('#LoginInput_UserNameOrEmailAddress').type('admin')
        cy.get('#LoginInput_Password').type('1q2w3E*')
        cy.get('button').should('have.attr', 'value', 'Login').click()
    })
    it(`shoud show table with ${column} column`, () => {
        cy.get('#TrainersTable').within(() => {
            cy.get('tr').first().children().should('have.length', column)
        })
    })
    it(`shoud create, edit, delete  trainer with name ${nameTest}`, () => {
        //create 
        cy.intercept('GET', 'Pages/Trainers/createModal.js').as('createTrainer')
        cy.get('#NewTrainerButton').click({ force: true })
        cy.wait('@createTrainer').its('response.statusCode').should('equal', 200)
        cy.get('[data-cy=form_create]').within(() => {
            cy.get('#Trainer_Name').clear().type(`${nameTest}`).should('have.value', nameTest)
            cy.get('#Trainer_PokemonId').select(selectedAvatar, { force: true })
            cy.get('button').contains('Save').should('contain.text', 'Save').click()
        })
        cy.wait(delay)
        //edit
        cy.get('#TrainersTable').within(() => {
            cy.get('[data-cy=trainer_name]').contains(`${nameTest}`).should('have.text', nameTest)
            cy.get('[data-cy=trainer_name]').contains(`${nameTest}`).parent().parent().as('selectedRowEdit')
            cy.get('@selectedRowEdit').within(() => {
                cy.get('button').click()
                cy.get('.dropdown-menu').should('be.visible').find('li').eq(0).click()
            })
        })
        cy.wait(delay)
        
        cy.intercept('GET', urlGet)
            .as('getTrainer')
        cy.get('[data-cy=form_edit]').within(() => {
            cy.get('#Trainer_Name').clear().type(`${nameTest}Test`).should('have.value', `${nameTest}Test`)
            cy.get('#Trainer_PokemonId').select(selectedAvatar)
            cy.get('button').contains('Save').should('contain.text', 'Save').click()
        })
        cy.wait('@getTrainer').its('response.statusCode').should('equal', 200)
        cy.wait(delay)
        //delete
        cy.get('#TrainersTable').within(() => {
            cy.get('[data-cy=trainer_name]').contains(nameEdit).should('have.text', nameEdit)
            cy.get('[data-cy=trainer_name]').contains(`${nameTest}`).parent().parent().as('selectedRowDel')
            cy.get('@selectedRowDel').within(() => {
                cy.get('button').click()
                cy.get('.dropdown-menu').should('be.visible').find('li').eq(1).click()
            })
        })
        cy.get('.swal2-container.swal2-center.swal2-backdrop-show').as('swal2')
        cy.get('@swal2').find('button').contains('OK').click()
        cy.wait(delay)
        cy.get('[data-cy=trainer_name]').should('not.have.text', nameEdit)
    })
   
})


