
    var div = $('#grid');
        $(div).kendoGrid({
        sortable: true,
            filterable: {
        mode: "row"
            },
            resizable: true,
            reorderable: true,
           // editable: "inline",
            columnMenu: true,
            pageable: {
        refresh: true,
                pageSizes: true,
                buttonCount: 5,
                pageSize: 10
            },
            dataSource: {
        type: "json",
                transport: {
        read: "../Api/GetCars",
                   
                },
                schema: {
        Model: {
        fields: {
                            Id: {type: "number", editable: false },
                            Year: {type: "number", validation: {required: true } },
                            Watch: {type: "number", validation: {required: true } },
                            Amount: {type: "number", validation: {required: true } },
                            Mileage: {type: "number", validation: {required: true } },
                            Mark: {type: "string", validation: {required: true } },
                            Model: {type: "string", validation: {required: true } },
                            Cost: {type: "number", validation: {required: true } },
                            State: {type: "string", validation: {required: true } },
                            Type: {type: "string", validation: {required: true } },
                            Transmission: {type: "string", validation: {required: true } },
                            PhotoUrl: {type: "string", validation: {required: true } },

                        }
                    }
                },


            },
           // toolbar: ["create"],
            columns:
            [{
        field: "Id",
                filterable: {
        cell: {
           // operator: "contains",
           // suggestionOperator: "contains",
                    }
                }
            },
            {
        field: "Mark",
                filterable: {
        cell: {
      //  operator: "contains",
                       // suggestionOperator: "contains",
                        // showOperators: false
                    }
                }
            },
            {
        field: "Model",
                filterable: {
        cell: {
        //operator: "contains",
                        //suggestionOperator: "contains",
                        // showOperators: false
                    }
                }
            },
            {
        field: "Watch",
                filterable: {
        cell: {
        showOperators: false
                    }
                }
            },
            {
        field: "Year",
                filterable: {
        cell: {
        showOperators: false
                    }
                }
            },
            {
        title: "Цена",
                field: "Cost",
                filterable: {
        cell: {
        showOperators: false
                    }
                }
            },
            {
        field: "State",
                filterable: {
        cell: {
        //operator: "contains",
                        //suggestionOperator: "contains",
                        // showOperators: false
                    }
                }
            },
            {
        field: "Mileage",
                filterable: {
        cell: {
        // showOperators: false
    }
    }
            },
            {
        field: "Type",
                filterable: {
        cell: {
       // operator: "contains",
                       // suggestionOperator: "contains",
                        // showOperators: false
                    }
                }
            },
            {
        field: "Amount",
                filterable: {
        cell: {
        showOperators: false
                    }
                }
            },
            {
        field: "Transmission",
                filterable: {
        cell: {
       // operator: "contains",
                        //suggestionOperator: "contains",
                        //showOperators: false
                    }
                },
                // editor: customEditor
            },
            {
        field: "PhotoUrl",
                sortable: false,
                filterable: false,
                template: `<img onmouseover="show(#: Id #)"  width='100px' src='#: PhotoUrl #'  ></img>`,

            },
            {
                // {command: ["edit", "destroy"], title: "&nbsp;", width: "250px" }
                filed: "Buttons",
                template: `<div class="dc" id="dc#: Id #" hidden><a href="Admin/Change/#: Id #">Изменить</a>/<a href="../Api/Delete/#: Id #">Удалить</a></div>`,
            }
            ]
        });



        function show(id) {
            $(".dc").attr("hidden", true);
            $("#dc" + id).removeAttr("hidden");
        }
