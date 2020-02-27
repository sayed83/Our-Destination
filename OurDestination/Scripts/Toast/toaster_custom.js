{
    toastr.options = {
        "debug": false, "positionClass": "toast-bottom-right", "onclick": null, "fadeIn": 300, "fadeOut": 1000, "timeOut": 5000, "extendedTimeOut": 1000, closeButton: true
    };
    function customFile(status, message){
        if (message != null) {
            if (status == "1") {

                toastr.success(message);

            }
            else if (status == "2") {

                toastr.warning(message);
            }
            else if (status == "3") {
                toastr.error(message);
            }
            else if (status == "0") {

                toastr.options.extendedTimeOut = 10000;
                toastr.error(message);
            }
            else if (status == "4") {

                toastr.options.extendedTimeOut = 5000;
                toastr.error(message);
            }
            else {
                toastr.options.extendedTimeOut = 10000;
                toastr.error(message);
            }
  

        }
    }
}
