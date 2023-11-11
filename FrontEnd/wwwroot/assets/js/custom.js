$(document).ready(function(){

    var table = $('dataTable').DataTable({

        buttons:['copy', 'csv', 'excel', 'pdf', 'print']
    });
    table.buttons().container()
        .appendTo('#dataTable_wrapper .col-md-6:eq(0)');

});