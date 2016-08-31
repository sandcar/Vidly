

(function () {
    "use strict";
    AppCore.ui.utils = {
        tables: {
            Init: function (options) {


                // 1.1 this reference
                var $that = this;

                /* Opções configuráveis*/
                var defaults = {
                    tableID: '#table',
                    contract: null
                }

                // 1.0 defaults:
                this.options = $.extend(defaults, options);

                this.SetDatatable();


            },
            SetDatatable: function () {

                var $maintable = $(this.options.tableID);

                var arr = this.SetColumnArray();


                var dtable = $maintable.DataTable({
                    ajax: {
                        url: '/api/' + this.options.contract,
                        dataSrc: ""
                    },
                    columns: arr


                });

                this.SetDelete(dtable);


            },
            SetDelete: function (dtable) {

                var $maintable = $(this.options.tableID);
                var apiurl = this.options.apiSrc;

                $maintable.on('click', '.js-Delete', function (e) {

                    var $btn = $(this);

                    bootbox.confirm("Are you shore that you whant to delete this customer?", function (result) {
                        if (result) {
                            $.ajax({
                                url: apiurl + $btn.data("customer-id"),
                                method: "DELETE",
                                success: function () {

                                    dtable.row($btn.parents("tr")).remove().draw();
                                    //$btn.parents("tr").remove();
                                    console.log("success")
                                }
                            });
                        }

                    });
                });


            },
            SetColumnArray: function () {

                var $that = this;

                if ($that.options.contract === 'customers') {
                    return [
                            {
                                data: "name",
                                render: function (data, type, innerobj) {
                                    // customer.id ou apenas data;
                                    return "<a href='" + $that.options.contract + "/edit/" + innerobj.id + "'>" + data + "</a>"
                                }
                            },
                            {
                                data: "memberShipType.name"
                            },
                            {
                                data: "id",
                                render: function (data) {
                                    return "<button class='btn btn-link js-Delete' data-customer-id='" + data + "'>Delete</button>"
                                }
                            }
                    ]

                }

            }

        }


    };

}());

