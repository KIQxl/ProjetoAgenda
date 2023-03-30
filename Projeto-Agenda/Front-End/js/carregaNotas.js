const mural = document.querySelector("#muralEventos");
const url = "https://localhost:7188/Evento"

retornaEventos(url);

async function retornaEventos (url){

    
    const response = await fetch(url);
    const eventos = await response.json();

    exibeEventos(eventos);


};


const exibeEventos = (eventos) => {

    eventos.forEach(evento => {
        
        const conteudoHtml = 
        `<div class="evento" data-evento-id="${evento.id}">
            <h1 class="titulo">${evento.titulo}</h1>
            <p class="data">${evento.data}</p>
            <p class="descr">${evento.descrição}</p>
        </div>`
        mural.innerHTML += conteudoHtml;
    });
};
