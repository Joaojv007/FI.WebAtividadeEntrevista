////console.log("TESTE DO JOAO VITOR");
////var urlIncluir = '@Url.Action("IncluirBeneficiario", "Cliente", new { area = "" })';
////var urlAlteracao = '@Url.Action("AlterarBeneficiario", "Cliente", new { area = "" })';
////var urlBeneficiarioList = '@Url.Action("BeneficiarioList", "Cliente", new { area = "" })';
function IncluirBeneficiario(nome, cpf) {
    console.log('entrou no incluir');
    $.ajax({
        url: urlPostBeneficiario,
        method: "POST",
        data: {
            "NOME": nome,
            "CPF": cpf
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

function CarregarLista(titulo, texto) {
    console.log("CarregarLista");
    if (document.getElementById("gridBeneficiarios"))
        $('#gridBeneficiarios').jtable({
            title: 'Beneficiários Cadastrados',
            paging: true,
            pageSize: 5,
            sorting: true,
            defaultSorting: 'Nome ASC',
            actions: {
                listAction: urlBeneficiarioList,
            },
            fields: {
                Nome: {
                    title: 'CPF',
                    width: '35%%'
                },
                Email: {
                    title: 'Nome',
                    width: '35%%'
                },
                Alterar: {
                    title: '',
                    display: function (data) {
                        return '<button onclick="window.location.href=\'' + urlAlteracao + '/' + data.record.Id + '\'" class="btn btn-primary btn-sm">Alterar</button>';
                    }
                }
            }
        });

    //if (document.getElementById("gridBeneficiarios"))
    //    $('#gridBeneficiarios').jtable('load');
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
    console.log("JQUERY FUNCIONAL");

    $('#formCadastroBeneficiario').submit(function (e) {
        e.preventDefault();
        var nome = $(this).find("#Nome").val();
        var cpf = $(this).find("#CPF").val();
        IncluirBeneficiario(nome, cpf);
    });
});
