var App = angular.module("pmweb", ["ui.utils.masks"]);



App.controller('HotelIndex', function ($scope) {

    $scope.Hoteis = [];


    $scope.List = function () {
        JSController.GetData("GET","Hotels/List", { }, function (retorno) {

            $scope.Hoteis = retorno;

            $scope.$apply();
        }, true);


    };

   

    $scope.Delete = function (hotel) {

        Swal.fire({
            title: 'Você deseja excluir este item?',
            showDenyButton: true,
            confirmButtonText: 'Sim',
            denyButtonText: 'Não',
        }).then((result) => {
            if (result.isConfirmed) {

                JSController.GetData("POST", "Hotels/Delete", { "id": hotel.id }, function (retorno) {

                    Swal.fire('Item excluído', '', 'warning');

                    $scope.List();

                }, true);
            } 
        })
    }

    $scope.List();

});

App.controller('HotelDetalhe', function ($scope) {

    var id = window.location.href.match(/(\d+)$/g);

    $scope.Hotel = {};
    $scope.Hotel.fotos = [];
    $scope.cnpj = "";
    $scope.Errors = [];
    $scope.QuartoAtivo = {};
    $scope.QuartoAtivo.fotos = [];

    $scope.DeleteQuarto = function (quarto) {

        Swal.fire({
            title: 'Você deseja excluir este item?',
            showDenyButton: true,
            confirmButtonText: 'Sim',
            denyButtonText: 'Não',
        }).then((result) => {
            if (result.isConfirmed) {

                JSController.GetData("POST", "Hotels/DeleteQuarto", { "id": quarto.id }, function (retorno) {

                    Swal.fire('Item excluído', '', 'warning');

                    GetAll();

                }, true);
            }
        })
    };

    $scope.EditarQuarto = function (quarto) {
        $scope.QuartoAtivo = quarto;
     
        $("#AdicionarQuartoModal").modal('toggle');
    };

    $scope.AbrirModalQuarto = function () {

        $("#AdicionarQuartoModal").modal('toggle');
    };

    $scope.AbrirModalInfo = function (quarto) {

        $scope.QuartoAtivo = quarto;
        $scope.QuartoAtivo.preco = "R$ " + $scope.QuartoAtivo.preco
        $("#InfoQuartoModal").modal('toggle');
    };

    $scope.FecharModalInfo = function () {

        $scope.QuartoAtivo = {};
        $("#InfoQuartoModal").modal('hide');
    };

    $scope.FecharModaQuarto = function () {

        $scope.QuartoAtivo = {};
        $("#AdicionarQuartoModal").modal('hide');
    };

    $scope.DeleteFoto = function (foto) {

        Swal.fire({
            title: 'Você deseja excluir este item?',
            showDenyButton: true,
            confirmButtonText: 'Sim',
            denyButtonText: 'Não',
        }).then((result) => {
            if (result.isConfirmed) {

                const index = $scope.QuartoAtivo.fotos.indexOf(foto);

                $scope.QuartoAtivo.fotos.splice(index, 1);

                $scope.$apply();

               
            }
        });
       
    };

    $scope.DeleteFotoHotel = function (foto) {

        Swal.fire({
            title: 'Você deseja excluir este item?',
            showDenyButton: true,
            confirmButtonText: 'Sim',
            denyButtonText: 'Não',
        }).then((result) => {
            if (result.isConfirmed) {

                const index = $scope.Hotel.fotos.indexOf(foto);

                $scope.Hotel.fotos.splice(index, 1);

                $scope.$apply();


            }
        });

    };

    $scope.Save = function () {

        $scope.Hotel.cnpj = $("#InputCNPJ").val().replace(".", "").replace(".", "").replace("/","").replace("-","");

        JSController.GetData("POST", "Hotels/SaveChange", { "hotel": $scope.Hotel}, function (retorno) {

            $scope.Errors = retorno;

            RestaureField();

            if ($scope.Errors.length > 0) {

                $.each($scope.Errors, function (index, item) {
                    AlertField(item.propertyName, item.errorMessage);
                });
            }
            else {
                Swal.fire(
                    'Salvo',
                    'Hotel salvo com sucesso!',
                    'success'
                );

                setTimeout(function () {
                    window.location.href = "../";
                }, 2000);
            }

        }, true);


    };

    $scope.SaveQuarto = function () {

        $scope.QuartoAtivo.hotelId = $scope.Hotel.id;

        if (typeof $scope.QuartoAtivo.preco != 'undefined') {


            try {
                $scope.QuartoAtivo.preco = $scope.QuartoAtivo.preco.replace("R$ ", "").replace(".", "").replace(",", ".");
            } catch (error) {
                console.error(error);

            }

            

        }
        

        JSController.GetData("POST", "Hotels/SaveQuarto", { "quarto": $scope.QuartoAtivo }, function (retorno) {

            $scope.Errors = retorno;

            RestaureField();

            if ($scope.Errors.length > 0) {

                $.each($scope.Errors, function (index, item) {
                    AlertField(item.propertyName, item.errorMessage);
                });
            }
            else {

                $scope.FecharModaQuarto();

                Swal.fire(
                    'Salvo',
                    'Quarto salvo com sucesso!',
                    'success'
                );

                GetAll();
            }

        }, true);


    };

    $scope.ConsultarCNPJ = function () {
       

        var cnpj = $('#InputCNPJ').val().replace(/[^0-9]/g, '');

        if (cnpj.length == 14) {

            $.ajax({
                method: 'GET',
                url: 'https://www.receitaws.com.br/v1/cnpj/' + cnpj,
                dataType: 'jsonp',
                complete: function (xhr) {

                    var response = xhr.responseJSON;

                    if (response.status == 'OK') {
                        $scope.Hotel.nome = capitalize(response.nome);
                        $scope.Hotel.endereco = capitalize(response.logradouro) + ', ' + response.numero;
                        $scope.$apply();

                        toastr.success('Informações do CNPJ Carregadas.', 'CNPJ Vinculado', { timeOut: 3000 });
                    }
                    else {
                        toastr.warning('Não foi possível encontrar esse CNPJ.', 'CNPJ Inválido', { timeOut: 3000 });
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {

                    toastr.error('Erro desconhecido.', 'Erro', { timeOut: 3000 });

                    goknop.attr({
                        disabled: false
                    });
                }
            });
        }
        else {
            if (cnpj.length > 0) {
                toastr.error('Tamanho do CNPJ menor que o esperado.', 'CNPJ Inválido', { timeOut: 3000 });
            }


        }
    }
    

    if (id != null) {
        GetAll();
    }

    function GetAll() {
        JSController.GetData("GET", "Hotels/Get", { "id": id[0] }, function (retorno) {

            $("#TituloPagina").html("Editar");

            $scope.Hotel = retorno;
            $scope.cnpj = retorno.cnpj;
            $scope.$apply();
        }, true);
    }
    
});




//Upload Foto Quarto
$(function () {
    $('#FileUploadFotoQuarto').fileupload({
        replaceFileInput: false,
        url: '/Arquivo/Upload',
        done: function (e, data) {

            var resultado = JSON.parse(JSON.stringify(data.result));

            if (resultado.status === "OK") {

                var scope = $('#HotelDetalhe').scope();

                if (scope.QuartoAtivo.fotos == null) {

                    scope.QuartoAtivo.fotos = [];
                }

                scope.QuartoAtivo.fotos.push({ 'arquivo': resultado.arquivo, 'nome': resultado.nome });
                scope.$apply();

                toastr.success('Upload de arquivo feito com sucesso.', 'Arquivo Salvo', { timeOut: 3000 });
            }
        },
        fail: function (e, data) {
            toastr.error('Erro ao enviar o arquivo.', 'Erro', { timeOut: 3000 });
        }
    });
});

// Upload Foto Hotel
$(function () {
    $('#FileUploadFoto').fileupload({
        replaceFileInput: false,
        url: '/Arquivo/Upload',
        done: function (e, data) {

            var resultado = JSON.parse(JSON.stringify(data.result));

            if (resultado.status === "OK") {

                var scope = $('#HotelDetalhe').scope();

                if (scope.Hotel.fotos == null) {

                    scope.Hotel.fotos = [];
                }

                scope.Hotel.fotos.push({ 'arquivo': resultado.arquivo, 'nome': resultado.nome });
                scope.$apply();

                toastr.success('Upload de arquivo feito com sucesso.', 'Arquivo Salvo', { timeOut: 3000 });
            }
        },
        fail: function (e, data) {
            toastr.error('Erro ao enviar o arquivo.', 'Erro', { timeOut: 3000 });
        }
    });
});