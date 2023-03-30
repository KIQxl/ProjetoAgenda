const form = document.querySelector("#cadastro-evento");
const btn = document.querySelector("#btn-agendar");

btn.addEventListener("click", (e) => {

    e.preventDefault();
    const evento = getDados(form);

    postEvento(evento);

    form.reset();
    
});

const getDados = (form) => {
    const data = form.dataEvento.value
    const nome = form.nomeEvento.value;
    const descricao = form.descricaoEvento.value

    const evento = obj(data, nome, descricao);
    
    return evento
}

const obj = (data , nome, descricao) => {
    const evento = 
    {   
        Data: data,
        Titulo: nome,
        Descrição: descricao
    };

    return evento
};

async function postEvento(evento){
    try{
        const response = await fetch("https://localhost:7188/Evento", {
        method: 'POST',
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(evento)
        });

        if(response.status === 200){
            window.location.href = "index.html"
        } else { 
            alert('Ops! Houve um erro');
        };
    } catch(erro){
        console.log(erro);
    };
};