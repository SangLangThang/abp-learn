var abp = abp || {};

abp.modals.trainerCreate = function () {
    var initModal = function (publicApi, args) {
        
        var idModal = publicApi.getModalId();
        var lastNpIdId = '';
        var lastNpDisplayNameId = '';

        var _lookupModal = new abp.ModalManager({
            viewUrl: abp.appPath + "Shared/LookupModal",
            scriptUrl: "/Pages/Shared/lookupModal.js",
            modalClass: "navigationPropertyLookup"
        });

        $('.lookupCleanButton').on('click', '', function () {
            $(this).parent().parent().find('input').val('');
        });

        _lookupModal.onClose(function () {
            var modal = $(_lookupModal.getModal());
            $('#' + lastNpIdId).val(modal.find('#CurrentLookupId').val());
            $('#' + lastNpDisplayNameId).val(modal.find('#CurrentLookupDisplayName').val());
        });
        $('#Trainer_PokemonId').select2({
            width: '100%',
            dropdownParent: $(`#${idModal}Container .modal`),
            templateResult: formatState
        });
        
    };

    return {
        initModal: initModal
    };
};
function formatState(state) {
    if (!state.id) {
        return state.text;
    }
    var $state = $(
        `<img data-cy="trainer_pokemon" src=${state.text} class="pokemon-avatar" >`
    );
    return $state;
    
};
