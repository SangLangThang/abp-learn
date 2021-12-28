/// <reference types="cypress" />

let lengthMenuItem = 9;

describe('Home Page', () => {
    beforeEach(() => {
        cy.visit('https://localhost:44316')
    })
    it('should have footer with text', () => {
        cy.get('footer span').should('contain', `2020 - ${new Date().getFullYear()}`)
    })
    it('should have two item in sidebar', () => {
        cy.get('#navbarSidebar').within(() => {
            cy.get('ul').first().children().should('have.length', 2)
        })
    })

})

describe('Login Page', () => {
    beforeEach(() => {
        cy.visit('https://localhost:44316/Account/Login')
    })
    it('should show error when input field invalid', () => {
        cy.get('#LoginInput_UserNameOrEmailAddress').type('adminerror')
        cy.get('#LoginInput_Password').type('1q2w3E*')
        cy.get('button').should('have.attr', 'value', 'Login').click()
        cy.get('#AbpPageAlerts').should('be.visible')
    })
    it('should login success with correct input field', () => {
        cy.get('#LoginInput_UserNameOrEmailAddress').type('admin')
        cy.get('#LoginInput_Password').type('1q2w3E*')
        cy.get('button').should('have.attr', 'value', 'Login').click()
        cy.url().should('eq', 'https://localhost:44316/')
        cy.get('#navbarSidebar').within(() => {
            cy.get('ul').first().children().should('have.length', lengthMenuItem)
        })
    })

})
