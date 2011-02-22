$(document).ready(function () {
    $(".datepicker").datepicker({
        showAnim: '',
        dateFormat: 'dd/mm/yy',
        showOn: 'button',
        buttonImageOnly: true,
        buttonImage: '../../Scripts/txtdropdown/txtdropdown-btn.png',
        buttonText: 'Selecione a data'
    });

    $(".timedropdown").timedropdown();
});

