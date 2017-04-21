function PageInit()
{
    $(document).ajaxStart(function () {
        $.blockUI({ message: null, css: { backgroundColor: '#000', color: '#fff', opacity: .1 } });
    }).ajaxStop($.unblockUI);
}


function Block()
{
    $.blockUI({ css: { backgroundColor: '#f00', color: '#fff' } });
}

function Unblock() {
    $.blockUI({ css: { backgroundColor: '#f00', color: '#fff' } });
}

function RenderContent(url) {
    if (url.length == 0)
    {
        return false;
    }
    //$.blockUI;
    //$(document).ajaxStart(Block()).ajaxStop($.unblockUI);
    //$(document).ajaxStart(function () {
    //    //show a progress modal of your choosing
    //    showProgressModal('loading');
    //});
    //$(document).ajaxStop(function () {
    //    //hide it
    //    hideProgressModal();
    //});

    $.ajax({
        url: url,
        dataType: 'html',
        success: function (data) {
            $('#render-body').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(ajaxOptions);
            alert(thrownError);
        }
    });
}