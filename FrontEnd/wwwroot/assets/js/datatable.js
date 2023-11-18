$(document).ready(function () {
    var table = $('#dataTable').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.13.1/i18n/es-ES.json"
        },
        //select: true,
        
        //dom: 'Blfrtip',
        //lengthMenu: [
        //    [10, 25, 50, -1],
        //    ['10', '25', '50', 'Todo']
        //],
        //dom: 'Blfrtip',
        //buttons: [
        //    { extend: 'copy', text: '<i  aria-hidden="true">COPIAR</i>' },
        //    { extend: 'csv', text: '<i >CSV</i>' },
        //    { extend: 'excel', text: '<i  aria-hidden="true">EXCEL</i>' },
        //    { extend: 'pdf', text: '<i  aria-hidden="true">PDF</i>' },
        //    'pageLength'
        //],
    }); 
    table.buttons().container()
        .appendTo('#datatable_wrapper .col-md-6:eq(0)');
});