/// <reference types="cypress" />

let column = 5;
let delay = 300;
let filterText = '';
let type = '';
let maxResultCount = 10;
const getUrl = (filterText, type, maxResultCount) => {
    return `/api/app/pokemons?filterText=${filterText}&avatar=&name=&slotMin=&slotMax=&type=${type}&sorting=slot%20asc&skipCount=0&maxResultCount=${maxResultCount}`
}
describe('Pokemons Page', () => {
    beforeEach(() => {
        cy.intercept('GET', getUrl(filterText, type, maxResultCount)).as('getPokemon')
        cy.visit('https://localhost:44316/Pokemons')
        cy.get('#LoginInput_UserNameOrEmailAddress').type('admin')
        cy.get('#LoginInput_Password').type('1q2w3E*')
        cy.get('button').should('have.attr', 'value', 'Login').click()
    })
    it(`shoud show table with ${column} column`, () => {
        cy.wait('@getPokemon').its('response.body.totalCount').should('equal', 400);
        cy.get('#PokemonsTable').within(() => {
            cy.get('tr').first().children().should('have.length', column)
        })
    })
    it(`shoud filter search type grass of pokemon with maxResultCount is ${maxResultCount} `, () => {
        filterText = 'grass';
        cy.intercept('GET', getUrl(filterText, type, maxResultCount)).as('searchPokemon')
        cy.get('#SearchForm').within(() => {
            cy.get('#FilterText').clear({ force: true }).type(filterText, { force: true })
            cy.get('button').click({ force: true })
        })
        cy.wait('@searchPokemon').its('response.body').then(body => {
            let items = [...body.items]
            let count = 0;
            let totalCount = body.totalCount
            let itemCount = items.length
            if (itemCount > 0) {
                for (let item of items) {
                    if (item.type === filterText) {
                        count++
                    }
                }
            }
            totalCount > maxResultCount ? expect(count).to.eq(itemCount) : expect(count).to.eq(totalCount)
        })
    })
    it(`shoud filter search type fire of pokemon with maxResultCount is ${maxResultCount + 15} `, () => {
        maxResultCount = maxResultCount + 15
        filterText = 'fire';
        cy.intercept('GET', getUrl(filterText, type, maxResultCount)).as('searchPokemon')
        cy.get('#PokemonsTable_length').within(() => {
            cy.get('select').select('25',{ force: true }) // config of backend 10 25 50 100
        })
        cy.wait(delay)
        cy.get('#SearchForm').within(() => {
            cy.get('#FilterText').clear({ force: true }).type(filterText, { force: true })
            cy.get('button').click({ force: true })
        })
        
        cy.wait('@searchPokemon').its('response.body').then(body => {
            let items = [...body.items]
            let count = 0;
            let totalCount = body.totalCount
            let itemCount = items.length
            if (itemCount > 0) {
                for (let item of items) {
                    if (item.type === filterText) {
                        count++
                    }
                }
            }
            totalCount > maxResultCount ? expect(count).to.eq(itemCount) : expect(count).to.eq(totalCount)
        })
        cy.wait(delay)
        cy.get('#PokemonsTable').within(() => {
            cy.get('tr').should('have.length', maxResultCount +1)
        })
    })
    it(`shoud checkbox search type bug of pokemon with maxResultCount is ${maxResultCount} `, () => {
        filterText = '';
        maxResultCount = 10;
        type = 'bug';
        cy.intercept('GET', getUrl(filterText, type, maxResultCount)).as('searchPokemon')
        cy.contains('Filter Pokemons').click({ force: true })
        cy.get('#Bug').check({ force: true })
        cy.wait('@searchPokemon').its('response.body').then(body => {
            let items = [...body.items]
            let count = 0;
            let totalCount = body.totalCount
            let itemCount = items.length
            if (itemCount > 0) {
                for (let item of items) {
                    if (item.type === type) {
                        count++
                    }
                }
            }
            totalCount > maxResultCount ? expect(count).to.eq(itemCount) : expect(count).to.eq(totalCount)
        })
        
    })
   
})


