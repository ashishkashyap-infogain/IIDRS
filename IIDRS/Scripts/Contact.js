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
    this.find('thead tr').append('<th name="buttons">Actions</th>');  //empty header
    this.find('tbody tr').append(colEdicHtml);
    var $tabedi = this;   //Read reference to the current table, to resolve "this" here.
    //Process "addButton" parameter
    if (params.$addButton != null) {
        //Parameter was provided
        params.$addButton.click(function () {

            rowAddNew($tabedi.attr("id"));
            flag = false;
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
        if (colsEdi == null) {  //was not defined
            return true;  //all are editable
        } else {  //there is field filter
            //alert('verificando: ' + idx);
            for (var i = 0; i < colsEdi.length; i++) {
                if (idx == colsEdi[i]) return true;
            }
            return false;  //It was not found
        }
    }
}
function FijModoNormal(but) {
    $(but).parent().find('#bAcep').hide();
    $(but).parent().find('#bCanc').hide();
    $(but).parent().find('#bEdit').show();
    $(but).parent().find('#bElim').show();
    var $row = $(but).parents('tr');  //access the row
    $row.attr('id', '');  //remove brand
}
function FijModoEdit(but) {

    $(but).parent().find('#bAcep').show();
    $(but).parent().find('#bCanc').show();
    $(but).parent().find('#bEdit').hide();
    $(but).parent().find('#bElim').hide();
    var $row = $(but).parents('tr');  //access the row
    $row.attr('id', 'editing');  //indicates that it is in edit
}
function ModoEdicion($row) {
    if ($row.attr('id') == 'editing') {
        return true;
    } else {
        return false;
    }
}
//function rowAcep(but) {
//    //Accept the changes to the edition
//    //  return false;
//    validateRow();
//    var $row = $(but).parents('tr');  //access the row
//    var $cols = $row.find('td');  //read fields
//    if (!ModoEdicion($row)) return;  //It is already in editing
//    //It is in edit.Editing has to be finished
//    IterarCamposEdit($cols, function ($td) {  //iterate through columns
//        var cont = $td.find('input').val(); //read input content 
       
//            $td.html(cont)
//          //pin content and remove controls
//    });
//    FijModoNormal(but);
//    //params.onEdit($row);
//    params.onEdit($cols);
//    flag = true;

//}

function rowAcep(but) {
     //Accept the changes to the edition
    var $row = $(but).parents('tr');  //accede a la fila
    var $cols = $row.find('td');  //lee campos
    if (validateData(but)) {
        if (!ModoEdicion($row)) return;  //Ya está en edición
        //Está en edición. Hay que finalizar la edición
        IterarCamposEdit($cols, function ($td) {  //itera por la columnas
            var cont = $td.find('input').val(); //lee contenido del input
            $td.html(cont);  //fija contenido y elimina controles
        });
        FijModoNormal(but);
        //params.onEdit($row);
        params.onEdit($cols);
        flag = true;
    }

}
function validateData(but) {
    var $row = $(but).parents('tr');
    var $cols = $row.find('td');
    var status = true;
    var i = 0
    var requiredCols = [0, 1, 2, 3]
    IterarCamposEdit($cols, function ($td) {
        var text = $td.find('input').val();
        if (requiredCols.indexOf(i) != -1 && text === "") {
            $td.find('input').addClass('required');
            status = false;
        }
        else {
            $td.find('input').removeClass('required');
        }
        i++;
    });
    return status;
}

function rowCancel(but) {
    //Reject edit changes
    var $row = $(but).parents('tr');  //access the row
    var $cols = $row.find('td');  //read fields
    if (!ModoEdicion($row)) return;  //It is already in editing
    //It is in edit.Editing has to be finished
    IterarCamposEdit($cols, function ($td) {  //iterate through columns
        var cont = $td.find('div').html(); //read content from div
                                            //pin content and remove controls
        var cont1 = $td.find('input').val();
        if (cont1 == "") {
            $row.remove(cont);
            window.location.reload();
        }
        else {
            $td.html(cont);
        }
    });
    FijModoNormal(but);
}
function rowEdit(but) {
    var $td = $("tr[id='editing'] td");
    rowAcep($td)
    var $row = $(but).parents('tr');
    var $cols = $row.find('td');
    if (ModoEdicion($row)) return;  //It is already in editing
    //Puts into edit mode
    IterarCamposEdit($cols, function ($td) {  //iterate through columns
        var cont = $td.html(); //read content
        var div = '<div style="display: none;">' + cont + '</div>';  //save content
        var input = '<input class="form-control input-sm"  value="' + cont.trim() + '">';
        $td.html(div + input);  //fix content
    });
    FijModoEdit(but);
}
function rowElim(but) {  //Delete current row
    var $row1 = $(but).parents('tr');
    var $row = $(but).parents('tr').find('td').eq(0);  //access the row
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
        for (let col = 0; col < 11; col++) {
            $('#editing').find('td').eq(col).text("");
            if (col == 1) {
                $('#editing').find('td').eq(col).append("fname");
            }
            if (col == 2) {
                $('#editing').find('td').eq(col).append("lname");
            }
            if (col == 3) {
                $('#editing').find('td').eq(col).append("email");
            }
            if (col == 4) {
                $('#editing').find('td').eq(col).append("phone");
            }
            if (col == 5) {
                $('#editing').find('td').eq(col).append("dropdown");
            }
            else if (col == 6) {
                $('#editing').find('td').eq(col).append("du");
            }
            else if (col == 7) {
                $('#editing').find('td').eq(col).append("proj");
            }
        }
        var $td = $("tr[id='editing'] td");
        IterarCamposEdit($cols, function ($td) {

            var div = '<div style="display: none;"></div>';
            var input = '<input class="form-control input-sm"  value="">';
            $td.html(div + input);

            //var fname = $cols[1].textContent;
            //var lname = $cols[2].textContent;

            //Set dropdown for new row contact column
            //var dropdown = "<select id='ddlBU' class='form-control' style='width: fit-content;'><option></option></select>";
            var dropdown = "<input list='ddlBUs1' id='ddlBUs' class='form-control listclass'  placeholder='Select' style='width: fit-content;'>" + "<datalist  id='ddlBUs1'></datalist >";
            if ($cols[5].textContent != "dropdown") {
                $td.html(div + dropdown);
            }
            
        });
        $ultFila.find('td:last').html(saveColHtml);
    }
    params.onAdd();
}
function TableToCSV(tabId, separator) {  //Convert table to CSV
    var datFil = '';
    var tmp = '';
    var $tab_en_edic = $("#" + tabId);  //Table source
    $tab_en_edic.find('tbody tr').each(function () {
        //Finish the edit if it exists
        if (ModoEdicion($(this))) {
            $(this).find('#bAcep').click();  // accept edition
        }
        var $cols = $(this).find('td');  //read fields
        datFil = '';
        $cols.each(function () {
            if ($(this).attr('name') == 'buttons') {
                //It's column of buttons
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
