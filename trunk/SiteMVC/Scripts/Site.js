$(document).ready(function () {
    $(".datepicker").datepicker({
        showAnim: '',
        dateFormat: 'm/d/yy',
        showOn: 'button',
        buttonImageOnly: true,
        buttonImage: '../Scripts/txtdropdown/txtdropdown-btn.png',
        buttonText: 'Select a date'
    });

    $(".timedropdown").timedropdown();
});
