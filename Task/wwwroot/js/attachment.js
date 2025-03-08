"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/attachmentHub").build();

connection.on("ReceiveMessage", function () {
    var dataGrid = $("#upload_grid").dxDataGrid("instance");
    dataGrid.refresh();
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});

