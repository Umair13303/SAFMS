﻿/*----------------------------------** GLOBAL VARIABLE FOR PAGE :: TABLE UM_USER                    **----------------------------------------------*/
var table = "";

/*----------------------------------** FUNCTION FOR::PAGE LOADER                                    **----------------------------------------------*/
$(document).ready(function () {
    InitDataTable();
    ChangeCase();
});

/*----------------------------------** FUNCTION FOR::DATA TABLE & OPERATION                         **----------------------------------------------*/
function InitDataTable() {
    var ParentGroupColumn = 1;

    table = $('#MainTableUM_User').DataTable({
        dom: '<"row"<"col-md-12"<"row"<"col-md-6"B><"col-md-6"f> > ><"col-md-12"rt> <"col-md-12"<"row"<"col-md-5"i><"col-md-7"p>>> >',
        buttons: {
            buttons: [
                { extend: 'copy', className: 'btn' },
                { extend: 'csv', className: 'btn' },
                { extend: 'excel', className: 'btn' },
                { extend: 'print', className: 'btn' },
            ]
        },
        "oLanguage": {
            "oPaginate": {
                "sPrevious": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-arrow-left"><line x1="19" y1="12" x2="5" y2="12"></line><polyline points="12 19 5 12 12 5"></polyline></svg>',
                "sNext": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-arrow-right"><line x1="5" y1="12" x2="19" y2="12"></line><polyline points="12 5 19 12 12 19"></polyline></svg>'
            },
            "sInfo": "Showing page _PAGE_ of _PAGES_",
            "sSearch": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-search"><circle cx="11" cy="11" r="8"></circle><line x1="21" y1="21" x2="16.65" y2="16.65"></line></svg>',
            "sSearchPlaceholder": "Search...",
            "sLengthMenu": "Results :  _MENU_"
        },
        "responsive": true,
        "ordering": true,
        "processing": true,
        "lengthMenu": [5,10, 25, 50, 75, 100],
        "columns": [
            { "data": null, "title": "#" },
            { "data": "GuID", "title": "GuID" },
            { "data": "Company", "title": "Company" },
            { "data": "Branch", "title": "Branch" },
            { "data": "Name", "title": "Name" },
            { "data": "UserName", "title": "User Name" },
            { "data": "EmailAddress", "title": "Email" },
            { "data": "MobileNumber", "title": "Mobile" },
            {
                "data": null, "title": "Status", "defaultContent": "",
                "render": function (data, type, full, meta) {
                    return GetStatus(data["DocumentStatus"]);
                }
            },

        ],
        columnDefs: [
            { visible: false, targets: 1 },
            { "orderable": false, targets: [0, 1, 2, 4, 5, 6] },
        ],
        order: [[ParentGroupColumn, 'asc']],
        drawCallback: function (settings) {
            DT_GroupBy_ForTableWithSubDetail(this, settings, '#MainTableUM_User', ['Company', 'Branch']);
        }

    });
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });

    }).draw();
}


/*----------------------------------** FUNCTION FOR::CHANGE CASE LOADER                             **----------------------------------------------*/
function ChangeCase() {
    $('#DropDownListSearchBy').change(function (event) {
        event.preventDefault();
        var SearchBy = $('#DropDownListSearchBy :selected').val();
        if (SearchBy == 1) {
            $('#TextBoxQueryString').prop('disabled', true);
        }
        else {
            $('#TextBoxQueryString').prop('disabled', false);
        }
    });
}

/*----------------------------------** FUNCTION FOR:: DATABASE OPERATION (VALIDATE,LOAD)            **----------------------------------------------*/
$('#ButtonSearch').click(function (event) {
    event.preventDefault();
    var IsValid = true;
    if (IsValid) {
        try {
            DrawDataTable();

        }
        catch {
            GetMessageBox(err, 500);
        }
    }
});
function DrawDataTable() {
    var SearchById = $('#DropDownListSearchBy :selected').val();
    var InputText = $('#TextBoxQueryString').val();
    var JsonArg = {
        SearchById: SearchById,
        InputText: InputText,
    };
    var queryString = $.param(JsonArg);
    table.ajax.url((BasePath + "/AUser/CUserManagmentUI/GET_MT_UM_USER_LIST_BY_SEARCHQUERY_FORDATATABLE?" + queryString)).load();
}










