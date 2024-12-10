async function carregarPratos() {
    try {
        // Chamada à API para buscar os pratos
        const response = await fetch('https://localhost:5000/api/pratos'); // Substitua pelo endpoint correto
        if (!response.ok) {
            throw new Error(`Erro na API: ${response.status}`);
        }

        const pratos = await response.json();

        // Obtém o elemento onde os pratos serão exibidos
        const menuItemsContainer = document.getElementById('menu-items'); // Substitua pelo ID correto

        if (!menuItemsContainer) {
            console.error("Elemento com ID 'menu-items' não encontrado na página.");
            return;
        }

        // Limpa o conteúdo existente
        menuItemsContainer.innerHTML = '';

        // Adiciona cada prato ao container
        pratos.forEach(prato => {
            const pratoHtml = `
                <div class="col-lg-6">
                    <div class="d-flex align-items-center">
                        <img class="flex-shrink-0 img-fluid rounded" 
                            src="${prato.imageUrl || 'img/placeholder.jpg'}" 
                            alt="${prato.name || 'Prato'}" 
                            style="width: 80px;">
                        <div class="w-100 d-flex flex-column text-start ps-4">
                            <h5 class="d-flex justify-content-between border-bottom pb-2">
                                <span>${prato.name || 'Nome não disponível'}</span>
                                <span class="text-primary">R$${prato.price ? prato.price.toFixed(2) : 'N/A'}</span>
                            </h5>
                            console.log('Pratos recebidos:', pratos);
                            <small class="fst-italic">${prato.description || 'Sem descrição disponível'}</small>
                        </div>
                    </div>
                </div>
            `;
            menuItemsContainer.insertAdjacentHTML("beforeend", pratoHtml);
        });
    } catch (error) {
        console.error('Erro ao carregar os pratos:', error);
    }
}

// Aguarda o carregamento do DOM para executar a função
document.addEventListener('DOMContentLoaded', carregarPratos);
