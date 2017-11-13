$(document).ready(function () {

 

    function appendToDom(view) {
        $("#bodyContent").empty();
        $("#bodyContent").append(view);
    
        setEventHandlers();
    
    }

    function sendAjax(action, method, data) {
        return $.ajax({
            url: action,
            success: function (returnData) {

                return returnData;
            },
            method: method,
            data: data,
            error: function (jqXHR, exception) {
                return jqXHR, exception;
            }
        });
    }

    function setEventHandlers() {

        
        $(".form").off("submit");
        $(".form").on("submit",
            function (e) {
                e.preventDefault();
                let form = this;
                if ($(this).valid()) {

                    let action = $(form).attr("data-post-action");
                    let method = "POST";
                    let data = {};
                    let inputs = $(form).find("input");
                    for (let i = 0; i < inputs.length; i++) {
                        let id = $(inputs[i])[0].name;
                        let duplicate = $(".details").length > 1;
                        let parent = inputs[i].parentElement;

                        if (!duplicate || !parent.hasAttribute("hidden")) {

                            data[id] = $(inputs[i]).val();
                        }
                    }
                    let req = sendAjax(action, method, data);
                    $.when(req).done(function (view) {
                        appendToDom(view);
                    }).fail(ajaxFail);
                }
            });


        $(".edit").off("click");
        $(".edit").on("click", function (e) {
            e.preventDefault();
            let action = $(this).attr("href");
            let data = { id: action.substring(action.lastIndexOf('/') + 1) };
            let method = "GET";
            let req = sendAjax(action, method, data);

            $.when(req).done(function (view) {
                appendToDom(view);

            }).fail(ajaxFail);


        });

        $("[data-action]").off("click");
        $("[data-action]").on("click", function (e) {
            e.preventDefault();
            let action = $(this).attr("data-action");
            let method = "GET";
            let req = sendAjax(action, method);
            $.when(req).done(function (view) {
                appendToDom(view);
            }).fail(ajaxFail);
        });

        function ajaxFail(data) {
            let h = data.statusMessage;
            appendToDom("An Error occured.");
        }


    }

   
   

    setEventHandlers();
});

