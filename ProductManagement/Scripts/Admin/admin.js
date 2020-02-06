var admin = function () {

    this.init = function () {
        //loadData();
        registerEvents();
    }

    var registerEvents = function () {

        $('body').on('click', '#btn-product-admin', function (e) {
            e.preventDefault();
           
            var a = document.getElementById("btn-link");

            a.innerHTML = 'Go to Users';
            setInterval(function () { a.href = '/Admin/Users'; }, 2000); 
            
            console.log('hello!');
        });

        
    }
}