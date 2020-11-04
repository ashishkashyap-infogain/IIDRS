/*
Bootstable
 @description  Javascript library to make HMTL tables editable, using Bootstrap
 @version 1.1
 @autor Tito Hinostroza
*/
"use strict";
//Global variables
var params = null;  		//Parameters
var colsEdi = null;
var flag = true;
var newColHtml = '<div class="btn-group pull-right">' +
    '<button id="bEdit" type="button" class="btn btn-sm btn-default"  onclick="rowEdit(this);">' +
    '<i class="fas fa-pencil-alt"></i>' +
    '</button>' +
    '<button id="bElim" type="button" class="btn btn-sm btn-default"  onclick="rowElim(this);">' +
    '<i class="fas fa-trash" aria-hidden="true"></i>' +
    '</button>' +
    '<button id="bAcep" type="button" class="btn btn-sm btn-default"  style="display:none;" onclick="rowAcep(this);">' +
    '<i class="fas fa-check"></i>' +
    '</button>' +
    '<button id="bCanc" type="button" class="btn btn-sm btn-default" style="display:none;"  onclick="rowCancel(this);">' +
    '<i class="fas fa-times" aria-hidden="true"></i>' +
    '</button>' +
    '</div>';

var saveColHtml = '<div class="btn-group pull-right">' +
    '<button id="bEdit" type="button" class="btn btn-sm btn-default" style="display:none;" onclick="rowEdit(this);">' +
    '<i class="fas fa-pencil-alt"></i>' +
    '</button>' +
    '<button id="bElim" type="button" class="btn btn-sm btn-default" style="display:none;" onclick="rowElim(this);">' +
    '<i class="fas fa-trash" aria-hidden="true"></i>' +
    '</button>' +
    '<button id="bAcep" type="button" class="btn btn-sm btn-default"   onclick="rowAcep(this);">' +
    '<i class="fas fa-check"></i>' +
    '</button>' +
    '<button id="bCanc" type="button" class="btn btn-sm btn-default"  onclick="rowCancel(this);">' +
    '<i class="fas fa-times" aria-hidden="true"></i>' +
    '</button>' +
    '</div>';
var colEdicHtml = '<td name="buttons">' + newColHtml + '</td>';
var colSaveHtml = '<td name="buttons">' + saveColHtml + '</td>';

$.fn.SetEditable = function (options) {
    var defaults = {
        columnsEd: null,         //Index to editable columns. If null all td editables. Ex.: "1,2,3,4,5"
        $addButton: null,        //Jquery object of "Add" button
        onEdit: function (row) { },   //Called after edition
        onBeforeDelete: function () { }, //Called before deletion
        onDelete: function (row) { }, //Called after deletion
        onAdd: function () { }     //Called when added a new row
    };
    params = $.extend(defaults, options);
    this.find('thead tr').append('<th name="buttons" id="actionHeader">Actions</th>');  //empty header
    this.find('tbody tr').append(colEdicHtml);
    var $tabedi = this;   //Read reference to the current table, to resolve "this" here.
    //Process "addButton" parameter
    if (params.$addButton != null) {
        //Parameter was provided
        params.$addButton.click(function () {
            if (flag == true) {
                rowAddNew($tabedi.attr("id"));
                flag = false;
            }
        });
    }
    //Process "columnsEd" parameter
    if (params.columnsEd != null) {
        //Extract felds
        colsEdi = params.columnsEd.split(',');
    }
};
function IterarCamposEdit($cols, tarea) {
    //Iterate through editable fields in a row
    var n = 0;
    $cols.each(function () {
        n++;
        if ($(this).attr('name') == 'buttons') return;  //exclude button column
        if (!EsEditable(n - 1)) return;   //editable field notes
        tarea($(this));
    });

    function EsEditable(idx) {
        // Indicates if the passed column is configured to be editable
        if (colsEdi == null) {  //no se definió
            return true;  //todas son editable
        } else {  //hay filtro de campos
            //alert('verificando: ' + idx);
            for (var i = 0; i < colsEdi.length; i++) {
                if (idx == colsEdi[i]) return true;
            }
            return false;  //no se encontró
        }
    }
}
function FijModoNormal(but) {
    $(but).parent().find('#bAcep').hide();
    $(but).parent().find('#bCanc').hide();
    $(but).parent().find('#bEdit').show();
    $(but).parent().find('#bElim').show();
    var $row = $(but).parents('tr');  //accede a la fila
    $row.attr('id', '');  //quita marca
}
function FijModoEdit(but) {
    $(but).parent().find('#bAcep').show();
    $(but).parent().find('#bCanc').show();
    $(but).parent().find('#bEdit').hide();
    $(but).parent().find('#bElim').hide();
    var $row = $(but).parents('tr');  //accede a la fila
    $row.attr('id', 'editing');  //indica que está en edición
}
function ModoEdicion($row) {
    if ($row.attr('id') == 'editing') {
        return true;
    } else {
        return false;
    }
}
function rowAcep(but) {
    //Acepta los cambios de la edición

    var $row = $(but).parents('tr');  //accede a la fila
    var $cols = $row.find('td');  //lee campos
    if (!ModoEdicion($row)) return;  //Ya está en edición
    //Está en edición. Hay que finalizar la edición
    IterarCamposEdit($cols, function ($td) {  //itera por la columnas
        var cont = $td.find('input').val(); //lee contenido del input
        $td.html(cont);  //fija contenido y elimina controles
    });
    FijModoNormal(but);
    params.onEdit($cols);
    flag = true;

}
function rowCancel(but) {
    var $row = $(but).parents('tr');  //accede a la fila
    var $cols = $row.find('td');  //lee campos
    if (!ModoEdicion($row)) return;  //Ya está en edición
    IterarCamposEdit($cols, function ($td) {  //itera por la columnas
        var cont = $td.find('div').html(); //lee contenido del div
        $row.remove(cont);
    });
    FijModoNormal(but);
}
function rowEdit(but) {
    var $td = $("tr[id='editing'] td");
    rowAcep($td)
    var $row = $(but).parents('tr');
    var $cols = $row.find('td');
    if (ModoEdicion($row)) return;  //Ya está en edición
    IterarCamposEdit($cols, function ($td) {  //itera por la columnas
        var cont = $td.html(); //lee contenido
        var div = '<div style="display: none;">' + cont + '</div>';  //guarda contenido
        var input = '<input class="form-control input-sm"  value="' + cont.trim() + '">';
        $td.html(div + input);  //fija contenido
    });
    FijModoEdit(but);
}
function rowElim(but) {  
    var $row1 = $(but).parents('tr');
    var $row = $(but).parents('tr').find('td').eq(0);  //accede a la fila
    params.onBeforeDelete($row1);
    $row1.remove();
    var res = confirm("Are you sure you want to delete?");
    if (res) {
        params.onDelete($row);
    }
    else {
        window.location.reload();
    }
}
function rowAddNew(tabId) {  //Add row to indicated table.
    var $tab_en_edic = $("#" + tabId);  //Table to edit
    var $filas = $tab_en_edic.find('tbody tr');
    if ($filas.length == 0) {
        //There are no rows of data. You have to create them complete
        var $row = $tab_en_edic.find('thead tr');  //header
        var $cols = $row.find('th');  // read fields
        //build html

        var htmlDat = '';
        $cols.each(function () {

            if ($(this).attr('name') == 'buttons') {
                //It's column of buttons

                htmlDat = htmlDat + colEdicHtml;  // add buttons
            }
            else {
                htmlDat = htmlDat + '<td></td>';
            }

        });
        $tab_en_edic.find('tbody').append('<tr>' + htmlDat + '</tr>');
    }
    else {
        //There are other rows, we can clone the last row, to copy the buttons
        var $ultFila = $tab_en_edic.find('tr').eq(1);
        $ultFila.clone().appendTo($ultFila.parent());
        $tab_en_edic.find('tr').eq(1).attr('id', 'editing');
        $ultFila = $tab_en_edic.find('tr').eq(1);
        var $cols = $ultFila.find('td');  // read fields
        for (let col = 0; col < 9; col++) {
            $('#editing').find('td').eq(col).text("");
            if (col == 6) {
                $('#editing').find('td').eq(col).append("dropdown");
            }
            else if (col == 7) {
                $('#editing').find('td').eq(col).append("email");
            }
            else if (col == 8) {
                $('#editing').find('td').eq(col).append("phoneno");
            }
        }
        var $td = $("tr[id='editing'] td");
        IterarCamposEdit($cols, function ($td) {

            var div = '<div style="display: none;"></div>';
            var input = '<input class="form-control input-sm"  value="">';
            $td.html(div + input);

            //Set dropdown for new row contact column
            var dropdown = "<select id='ddlContacts' class='form-control' style='width: fit-content;'><option></option></select>";
            if ($cols[6].textContent != "dropdown") {
                $td.html(div + dropdown);
            }
        });
        $ultFila.find('td:last').html(saveColHtml);
    }
    params.onAdd();
}
function TableToCSV(tabId, separator) {  //Convierte tabla a CSV
    var datFil = '';
    var tmp = '';
    var $tab_en_edic = $("#" + tabId);  //Table source
    $tab_en_edic.find('tbody tr').each(function () {
        //Termina la edición si es que existe
        if (ModoEdicion($(this))) {
            $(this).find('#bAcep').click();  //acepta edición
        }
        var $cols = $(this).find('td');  //lee campos
        datFil = '';
        $cols.each(function () {
            if ($(this).attr('name') == 'buttons') {
                //Es columna de botones
            } else {
                datFil = datFil + $(this).html() + separator;
            }
        });
        if (datFil != '') {
            datFil = datFil.substr(0, datFil.length - separator.length);
        }
        tmp = tmp + datFil + '\n';
    });
    return tmp;
}
