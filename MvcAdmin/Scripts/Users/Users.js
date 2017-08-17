var isPostBack = false;
function InitPage() {
    if (!isPostBack) {
        $("#Query").click(function () {
            Query(1)
        });
    }
}

function Query(GoPage) {
    
    //$("#txtNOWPAGE").val('1');
    //$("#hiddenGoPage").val('1');
    //if (IsNumeric(GoPage)) {
    //    $("#txtNOWPAGE").val(GoPage);
    //    $("#hiddenGoPage").val(GoPage);
    //}
    //if (!IsNumeric($("#ddlPageNum option:selected").val()) || !parseInt($("#ddlPageNum option:selected").val(), 10) > 0)
    //    $('#ddlPageNum').val('10');

    var queryCondition = '';
    $(".query").each(function () {
        queryCondition += "&" + $(this).attr("id") + "=" + $(this).val();
    });

    //var actionMode = 'Query';
    //var pageShow = $("#ddlPageNum option:selected").val();
    //var pageNow = $("#txtNOWPAGE").val();

    //$('#QUERY_BLOCK').block(BlockUISetting2);
    //alert(queryCondition);

    //var data = {
    //    "players[0].Id": "P01",
    //    "players[0].Name": "Jeffrey",
    //    "players[1].Id": "P02",
    //    "players[1].Name": "Darkthread"
    //};
    //$.post('Users/Index', data, function (res) {
    //    alert(JSON.stringify(res));
    //}, "json");

    $.ajax({
        url: 'Users/Select',
        type: 'POST',
        data: queryCondition,
        success: function (users) {
            //alert(result);
            //var users = jQuery.parseJSON(result);
            //console.log(users)
            var htmlRow = "";
            $.each(users, function (idx, row) {
                htmlRow = '<tr>';
                htmlRow += '<td>' + row.USR_ID + '</td>';
                htmlRow += '<td>' + row.USR_NAME + '</td>';
                htmlRow += '<td>' + row.EMAIL + '</td>';
                htmlRow += '<td>' + row.USR_STATUS + '</td>';
                htmlRow += '<td>' + row.MEMO + '</td>';
                htmlRow += '<td>' + new Date(parseInt(row.CDATE.replace(/\D/igm, ""))).toLocaleString() + '</td>';
                htmlRow += '<td>' + row.CUSER + '</td>';
                htmlRow += '<td>' + new Date(parseInt(row.MDATE.replace(/\D/igm, ""))).toLocaleString() + '</td>';
                htmlRow += '<td>' + row.MUSER + '</td>';
                htmlRow += '</tr>';
                $('#gridview >  tbody').append(htmlRow);
            });
            //alert(obj[0].USR_ID);
            //alert(result);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('' + xhr.status + ';' + ajaxOptions + ';' + thrownError);
        },
        complete: function (xhr, status) {
            //alert('complete');
        }
    });

    //$.ajax({
    //    type: 'POST',
    //    url: 'Users/Index',
    //    data: "DOMODE=" + actionMode + "&PAGENOW=" + pageNow + "&PAGESHOW=" + pageShow + containStr + SYSTEM_PARAM,
    //    success: function (msg) {
    //        alert('success');
    //        var result;

    //        //解析json訊息
    //        //try { result = eval(String(msg)); } catch (e) { alert('未知訊息: ' + msg); $('#ASSIST_DIALOG').unblock(); return; }

    //        //查看錯誤訊息
    //        if (typeof (result[0].ERRORTEXT) != "undefined") {
    //            $('#ASSIST_DIALOG').unblock();
    //            alert(result[0].ERRORTEXT);
    //            return;
    //        }

    //        //清空table 資料
    //        $('#ResultTable >  tbody').html('');
    //        $("#divPageControl").css({ display: "none" });

    //        //判斷是否有資料
    //        if (result[0].ROWS.length == 0) {
    //            $('#ASSIST_DIALOG').unblock();
    //            $("#PageControl").css({ display: "none" });
    //            return;
    //        }
    //        $("#TOTALPAGE").html(result[0].TOTALPAGE);
    //        $("#TOTALRECOUNT").html(result[0].TOTALRECOUNT);
    //        $("#RECOUNTRANGE").html(result[0].RECOUNTRANGE);

    //        $("#PageControl").css({ display: "block" });

    //        //組合每一行資料、並丟到talbe裡
    //        var RowString = "";
    //        for (var Rows in result[0].ROWS) {
    //            RowString = "<TR>";
    //            RowString += '<TD style="font-size:12px;padding:2px;">' + result[0].ROWS[Rows]["CUSTACCT"] + '</TD>';
    //            RowString += '<TD style="font-size:12px;padding:2px;" align="left" >' + result[0].ROWS[Rows]["CUSTNAME"] + '</TD>';
    //            RowString += '<TD style="font-size:12px;padding:2px;">' + result[0].ROWS[Rows]["CSEX"] + '</TD>';
    //            RowString += '<TD style="font-size:12px;padding:2px;">' + result[0].ROWS[Rows]["CUSTTEL2"] + '</TD>';
    //            RowString += '<TD style="font-size:12px;padding:2px;">' + result[0].ROWS[Rows]["CUSTTEL1"] + '</TD>';
    //            RowString += '<TD style="font-size:12px;padding:2px;">' + result[0].ROWS[Rows]["INSERTDATE"] + '</TD>';
    //            RowString += '<TD></TD>';
    //            RowString += '<TD></TD>';
    //            RowString += '<TD></TD>';
    //            RowString += "</TR>";

    //            $('#ResultTable >  tbody').append(RowString);
    //        }

    //        //建立調閱欄位link
    //        var RImg = "<img alt='重設密碼' src='../../images/reset.gif' border='0' onclick='doRESETPWD(\"<ReplaceMe>\");' />";
    //        var UImg = "<img alt='修改' src='../../images/upd.gif' border='0' onclick='doUPD(\"<ReplaceMe>\");' />";
    //        var EImg = "<img alt='重寄' src='../../images/email.png' border='0' onclick='doSEND(\"<ReplaceMe>\");' />";
    //        var rownum = 0;
    //        $('#ResultTable tbody tr').each(function () {
    //            $(this).find("td").eq(6).html(RImg.replace('<ReplaceMe>', rownum));
    //            $(this).find("td").eq(7).html(UImg.replace('<ReplaceMe>', rownum));
    //            $(this).find("td").eq(8).html(EImg.replace('<ReplaceMe>', rownum));
    //            rownum++;
    //        });

    //        //建立table css特效
    //        $("#ResultTable tbody tr:odd").addClass("tr4");
    //        $("#ResultTable tbody tr:even").addClass("tr5");
    //        $("#ResultTable tbody tr").mouseover(function () {
    //            $(this).addClass("HighlightRow");
    //        }).mouseout(function () {
    //            $(this).removeClass("HighlightRow");
    //        });

    //        $(".subBtn").button();

    //        ResultTableJson = result;


    //    },
    //    error: function (xhr, ajaxOptions, thrownError) {
    //        alert('' + xhr.status + ';' + ajaxOptions + ';' + thrownError);
    //    },
    //    complete: function () {

    //        alert('complete');
    //        $('#QUERY_BLOCK').unblock();
    //        DivSH("QUERY_BLOCK");
    //    }
    //});
}