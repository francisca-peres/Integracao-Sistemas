from time import sleep
import java.net.URL as URL
import java.io.OutputStreamWriter as OutputStreamWriter

ficheiro = r"C:\\SikuliDados\\dados_gerados.txt"
primeira_vez = True
max_dados = 2
contador = 0

while contador < max_dados:
    App.focus("Form1")
    sleep(1)

    if not primeira_vez:
        for _ in range(5):  # Voltar para o campo inicial
            type(Key.TAB, KeyModifier.SHIFT)
            sleep(0.1)

        for _ in range(5):  # Apagar campos
            type("a", Key.CTRL)
            type(Key.BACKSPACE)
            type(Key.TAB)
            sleep(0.2)
    else:
        primeira_vez = False

    # Clica no botão "Gerar Dados"
    type(Key.ENTER)
    print("[Sikuli] Botão 'Gerar Dados' clicado.")
    sleep(2)

    # Lê os dados do ficheiro
    with open(ficheiro, "r") as f:
        linhas = f.readlines()

    data_producao = linhas[0].split("=")[1].strip()
    hora = linhas[1].split("=")[1].strip()
    codigo = linhas[2].split("=")[1].strip()
    tempo = linhas[3].split("=")[1].strip()
    resultado = linhas[4].split("=")[1].strip()

    # Voltar ao campo inicial
    for _ in range(5):
        type(Key.TAB, KeyModifier.SHIFT)
        sleep(0.1)

    # Preencher os campos
    for valor in [data_producao, hora, codigo, tempo, resultado]:
        type(valor)
        type(Key.TAB)
        sleep(0.2)

    print("[Sikuli] Dados preenchidos no formulário.")

    # Enviar para a API
    try:
        url = URL("http://localhost:5169/api/Produtos")
        conn = url.openConnection()
        conn.setDoOutput(True)
        conn.setRequestMethod("POST")
        conn.setRequestProperty("Content-Type", "application/json")

        json_data = (
            '{'
            + '"codigo_Peca": "' + codigo + '", '
            + '"data_Producao": "' + data_producao + '", '
            + '"hora_Producao": "' + hora + '", '
            + '"tempo_Producao": ' + tempo + ', '
            + '"codigo_Resultado": "' + resultado + '"'
            + '}'
        )

        writer = OutputStreamWriter(conn.getOutputStream())
        writer.write(json_data)
        writer.flush()
        writer.close()

        response_code = conn.getResponseCode()
        if response_code == 200:
            print("[Sikuli] Dados enviados para a API com sucesso.")
        else:
            print("[Sikuli] Erro ao enviar para API. Código HTTP:", response_code)

    except Exception as e:
        print("[Sikuli] Erro inesperado ao enviar para API:", str(e))

    contador += 1
    sleep(10)

print("[Sikuli] Fim da automação. Foram gerados {} conjuntos de dados.".format(max_dados))
