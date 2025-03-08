

/**
 * created by   : dwi.prasetyo
 * created date : 2024.03.09 
 * description  : return result from the backend rest-API
 * @param {*} methodOption, such as POST, GET, PUT, DELETE
 * @param {*} endpoint, string endpoint to resquest 
 * @param {*} payload, provided parameter, set null if not available
 * @returns 
 */
 function httpService(methodOption, endpoint, payload) {

    console.log(`Execute httpService to ${endpoint}`)

    return $.ajax({
        dataType: "json",
        url: endpoint,
        type: methodOption,
        data: payload,
        success: function (response) {
            result = response; //.data;
            // console.log('httpService success result : ', JSON.stringify(result))
        },
        error: function (e) {
            console.log('error occured...', e);
        }
    });
};

function tempe() {
    alert('tempe');
};

/**
 * created by   : dwi.prasetyo
 * created date : 2024.03.09 
 * description  : populate datasource into devextreme datagrid
 * @param {*} datagridId, datagrid id inside div element
 * @param {*} datasource json dataset as a datasource
 */
function initDataGrid_(gridId, controller, restOption, payload) {

    httpService('POST', 'GetBODList', payload).done(function (response) {
        if (response.success) {
            setTimeout(() => {
                /*console.log(`response.data: ${response.data}`); */
                $(`#${gridId}`).dxDataGrid({
                    dataSource: JSON.parse(response.data),
                });

//  $("#grid-bod").dxDataGrid("instance").endCustomLoading(); 
            }, 0);
        }
    });    

    
};

function showLoadingGrid(gridId) {

};

function hideLoadingGrid(gridId) {

};
