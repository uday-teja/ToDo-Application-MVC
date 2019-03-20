$(document).ready(function () {
    $(".task-circle").click(function () {
        $(this).toggleClass("task-circle-active");
    });
});

$(function () {
    $(".datepicker").datepicker();
});