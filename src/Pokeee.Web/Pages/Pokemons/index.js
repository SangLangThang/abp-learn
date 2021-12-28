$(function () {
    var l = abp.localization.getResource("Pokeee");
	
	var pokemonService = window.pokeee.pokemons.pokemons;
    var trainerService = window.pokeee.trainers.trainers;
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Pokemons/CreateModal",
        scriptUrl: "/Pages/Pokemons/createModal.js",
        modalClass: "pokemonCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Pokemons/EditModal",
        scriptUrl: "/Pages/Pokemons/editModal.js",
        modalClass: "pokemonEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            avatar: $("#AvatarFilter").val(),
			name: $("#NameFilter").val(),
			slotMin: $("#SlotFilterMin").val(),
			slotMax: $("#SlotFilterMax").val(),
			type: $("#TypeFilter").val()
        };
    };
    const colors = {
        normal: '#F5F5F5',
        fire: '#FDDFDF',
        grass: '#DEFDE0',
        electric: '#FCF7DE',
        water: '#DEF3FD',
        ground: '#f4e7da',
        rock: '#d5d5d4',
        fairy: '#fceaff',
        poison: '#98d7a5',
        bug: '#f8d5a3',
        dragon: '#97b3e6',
        psychic: '#eaeda1',
        flying: '#F5F5F5',
        fighting: '#E6E0D4'
    };

    var dataTable = $("#PokemonsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[3, "asc"]],
        ajax: abp.libs.datatables.createAjax(pokemonService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Select"),
                                visible: abp.auth.isGranted('Pokeee.Pokemons.Select'),
                                action: function (data) {
                                    console.log("selected:", data)
                                }
                            },
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Pokeee.Pokemons.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Pokeee.Pokemons.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    pokemonService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                data: "avatar",
                render: function (avatar) {
                    if (avatar === undefined ||
                        avatar === null) {
                        return "";
                    }
                    return `<img src=${avatar} class="pokemon-avatar" >`
                }
            },
			{ data: "name" },
            {
                data: "slot",
                render: function (slot) {
                    return `#${slot.toString().padStart(3, '0')}`
                }
            },
            {
                data: "type",
                render: function (type) {
                    return `<h4><span class="badge" daya-cy="type_pokemon" style="background-color:${colors[type]}; color:black;">${type}</span></h4>`
                }
            }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewPokemonButton").click(function (e) {
        e.preventDefault();
        //createModal.open();
        const pokemons_number = 400;
        const getPokemon = async id => {
            const url = `https://pokeapi.co/api/v2/pokemon/${id}`;
            const res = await fetch(url);
            const pokemon = await res.json();
            const name = pokemon.name[0].toUpperCase() + pokemon.name.slice(1);
            const slot = pokemon.id
            const poke_types = pokemon.types.map(type => type.type.name).filter(type => type != "normal" );
            const type = poke_types.length <= 0 ? "normal" : poke_types[0]
            const avatar = pokemon.sprites.front_default
            await pokemonService.create({
                name: name,
                slot: slot,
                type: type,
                avatar: avatar
            })
        };
        const fetchPokemons = async () => {
            for (let i = 301; i <= pokemons_number; i++) {
                await getPokemon(i);
            }
            dataTable.ajax.reload();
        };
        fetchPokemons()
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reload();
    });

    $('#AdvancedFilterSectionToggler').on('click', function (e) {
        $('#AdvancedFilterSection').toggle();
    });

    $('#AdvancedFilterSection').on('keypress', function (e) {
        if (e.which === 13) {
            dataTable.ajax.reload();
        }
    });
    
    $('#AdvancedFilterSection select').change(function() {
        dataTable.ajax.reload();
    });
    $('#Bug').change(function () {
        if (this.checked) {
            $("#TypeFilter").val("bug")
        }
        else {
            $("#TypeFilter").val("")
        }
        dataTable.ajax.reload();
    });
   
    $('#MinSlot10').change(function () {
        if (this.checked) {
            $("#SlotFilterMin").val("10")
        }
        else {
            $("#SlotFilterMin").val("")
        }
        dataTable.ajax.reload();
    });
});
