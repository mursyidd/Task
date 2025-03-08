function auto_approve(data) {
    if (data.auto_approve == true) {
        $.ajax({
            url: '@Url.Action("WFAction","Task")',
            type: "POST",
            dataType: "json",
            data: { "req": data.wf_req },
            success: function (data2) {

            }

        });


    }
}