const eventos = document.querySelector('#muralEventos')
const dialogAlt = document.querySelector('#alterar');
const btnClose = document.querySelector('#close');
const btnPut = document.querySelector('#btn-put');
const formAlt = document.querySelector("#formAlt");
const btnDelete = document.querySelector("#btn-delete")

let eventoId;

// evento que fará a exibição do modal que retornará as informações do banco de dados (eventos de agenda) clicado 
eventos.addEventListener('dblclick', async function(e){

    e.preventDefault();

    //condicional para que seja exibido o modal somente se uma nota (post it) for clicada
    if(e.target.parentNode.className == 'evento'){

        //identificando qual o id no banco de dados do post it clicado
        const evento = e.target.closest('.evento');
        eventoId = evento.dataset.eventoId;

        // função que retorna o evento
        const eventoJson = await buscaEvento(parseInt(eventoId));

        // abrindo o modal
        dialogAlt.showModal();

        // preenchendo os campos com o evento do banco de dados
        retornaEvento(formAlt, eventoJson);
    }
})


// botão que faz alteração no banco
btnPut.addEventListener('click', (e) => {
    e.preventDefault();

    //selecionando dados que vão ser alterados
    const eventoUptade = novoEvento(formAlt);

    //enviando a requisição para a API
    updateEvento(eventoUptade, eventoId);

    window.location.href = "index.html"
})


// fechar modal
btnClose.addEventListener('click', () => {
    dialogAlt.close();
})


// requisição GET
async function buscaEvento(id){
    const url = `https://localhost:7188/Evento/${id}`
    const response = await fetch(url)
    const evento = await response.json()
    
    return evento;
}


function retornaEvento(form, evento){
    form.altName.value = evento.titulo;
    form.altDate.value = evento.data;
    form.altDescr.value = evento.descrição;
}

function novoEvento(form){
    const evento = {
        titulo: form.altName.value,
        data: form.altDate.value,
        descrição: form.altDescr.value
    }

    return evento
}

//Requisição PUT
function updateEvento(evento, id){

    axios.put(`https://localhost:7188/Evento/${id}`, evento)
    .then(response => {
        console.log(response.status)
    })
    .catch(error => console.log(error))
}


//requisição DELETE
function deleteEvento(id){
    axios.delete(`https://localhost:7188/Evento/${id}`)
    .then(response => console.log(response.status))
    .catch(error => console.log(error));
}


//botão de deletar post it
btnDelete.addEventListener('click', (e) => {
    e.preventDefault();

    deleteEvento(eventoId);
    window.location.href = "index.html"
})