var productController = function () {

    this.init = function () {
        //loadData();
        registerEvents();
    }

    var registerEvents = function () {
        $('body').on('click', '#home', function (e) {
            e.preventDefault();
            location.reload(true);
        });

        $('body').on('click', '#accessories', function (e) {
            e.preventDefault();
            var id = 1;
            findById(id);
        });

        $('body').on('click', '#desktop', function (e) {
            e.preventDefault();
            var id = 2;
            findById(id);
        });

        $('body').on('click', '#ip_phone', function (e) {
            e.preventDefault();
            var id = 3;
            findById(id);
        });

        $('body').on('click', '#laptop', function (e) {
            e.preventDefault();
            var id = 4;
            findById(id);
        });

        $('body').on('click', '#monitor', function (e) {
            e.preventDefault();
            var id = 5;
            findById(id);
        });

        $('body').on('click', '#server', function (e) {
            e.preventDefault();
            var id = 6;
            findById(id);
        });

        $('body').on('click', '#smartphone', function (e) {
            e.preventDefault();
            var id = 7;
            findById(id);
        });
    }

    //function loadData() {

    //}

    function findById(id) {
        var html1 = '';
        var template = $('#dataProduct').html();
        $.ajax({
            url: '/Product/Index2',
            data: {             
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                $("#list_product").empty();
                console.log(response);
                $.each(response, function (i, item) {
                    html1 += Mustache.render(template, {
                        ID: item.ID,
                        Name: item.Name,
                        Description: item.Description,
                        NumberInStock: item.NumberInStock,
                        CategoryID: item.CategoryID
                    });
                });
                $('#lstProduct').html(html1);
            },
            error: function (err) {               
                alert('error')
            }
        });
    }
}