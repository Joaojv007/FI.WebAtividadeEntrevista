function IncluirBeneficiario(nome, cpf, idcliente) {
    $.ajax({
        url: urlPostBeneficiario,
        method: "POST",
        data: {
            "NOME": nome,
            "CPF": cpf,
            "IdCliente": idcliente,
        },
        error: function (r) {
            if (r.status == 400)
                ModalDialog("Ocorreu um erro", r.responseJSON);
            else if (r.status == 500)
                ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
        },
        success: function (r) {
            ModalDialog("Sucesso!", r)
            $("#formCadastroBeneficiario")[0].reset();
        }
    });
}

function CarregarLista(idCliente) {
    document.getElementById("idCliente").value = idCliente;

    if (document.getElementById("gridBeneficiarios")) {
        $('#gridBeneficiarios').jtable({
            title: 'Beneficiários Cadastrados',
            paging: true,
            pageSize: 5,
            sorting: true,
            defaultSorting: 'Nome ASC',
            actions: {
                listAction: function (postData, jtParams) {
                    postData = postData || {};
                    postData.idCliente = idCliente;
                    return $.Deferred(function ($dfd) {
                        $.ajax({
                            url: urlBeneficiarioList,
                            type: 'POST',
                            dataType: 'json',
                            data: postData,
                            success: function (data) {
                                $dfd.resolve(data);
                            },
                            error: function (err) {
                                $dfd.reject(err);
                            }
                        });
                    });
                }
            },
            fields: {
                CPF: {
                    title: 'CPF',
                    width: '35%'
                },
                Nome: {
                    title: 'Nome',
                    width: '35%'
                },
                Alterar: {
                    title: '',
                    display: function (data) {
                        return '<button onclick="window.location.href=\'' + urlAlteracao + '/' + data.record.Id + '\'" class="btn btn-primary btn-sm">Alterar</button>';
                    }
                }
            }
        });

        $('#gridBeneficiarios').jtable('load');
    }
}


function ModalDialog(titulo, texto) {
    var random = Math.random().toString().replace('.', '');
    var texto = '<div id="' + random + '" class="modal fade">                                                               ' +
        '        <div class="modal-dialog">                                                                                 ' +
        '            <div class="modal-content">                                                                            ' +
        '                <div class="modal-header">                                                                         ' +
        '                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>         ' +
        '                    <h4 class="modal-title">' + titulo + '</h4>                                                    ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-body">                                                                           ' +
        '                    <p>' + texto + '</p>                                                                           ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-footer">                                                                         ' +
        '                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>             ' +
        '                                                                                                                   ' +
        '                </div>                                                                                             ' +
        '            </div><!-- /.modal-content -->                                                                         ' +
        '  </div><!-- /.modal-dialog -->                                                                                    ' +
        '</div> <!-- /.modal -->                                                                                        ';

    $('body').append(texto);
    $('#' + random).modal('show');
}

$(document).ready(function () {
    $('#formCadastroBeneficiario').submit(function (e) {
        e.preventDefault();
        var nome = $(this).find("#Nome").val();
        var cpf = $(this).find("#CPF").val();
        var idCLiente = document.getElementById("idCliente").value;;
        IncluirBeneficiario(nome, cpf, idCLiente);
    });
});
