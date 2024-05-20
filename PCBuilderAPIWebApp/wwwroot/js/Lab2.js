const components = {
    case: [],
    motherboard: [],
    processor: [],
    gpu: [],
    'cpu-cooler': [],
    ram: [],
    memory: [],
    'power-supply': []
};

const componentDetails = {
    case: {},
    motherboard: {},
    processor: {},
    gpu: {},
    'cpu-cooler': {},
    ram: {},
    memory: {},
    'power-supply': {}
};
/*
async function loadComponents() {
    try {
        for (let component in components) {
            const response = await fetch(`/api/${component}s`);
            components[component] = await response.json();
            populateDropdown(component, components[component]);
        }
    } catch (error) {
        console.error('Error loading components:', error);
    }
}
*/
/*
function addComponent() {
    const componentType = document.getElementById('component-type').value;
    const componentName = document.getElementById('component-name').value;
    const componentPrice = document.getElementById('component-price').value;

    // Add your logic to handle the component addition
    console.log(`Adding ${componentType}: ${componentName} with price ${componentPrice}`);
}
*/
/*

async function loadComponents() {
    try {
        for (let component in components) {
            const response = await fetch(`/api/${component}s`);
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            components[component] = await response.json();
            populateDropdown(component, components[component]);
        }
    } catch (error) {
        console.error('Error loading components:', error);
    }
}
*/

/*
// Функція для завантаження компонентів
async function loadComponents(url, dropdownId) {
    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.json();

        // Отримання масиву об'єктів з властивості $values
        const items = data.$values;

        // Перевірка, чи items є масивом
        if (!Array.isArray(items)) {
            throw new Error('Response is not an array');
        }

        const dropdown = document.getElementById(dropdownId);
        dropdown.innerHTML = ''; // Очистити попередні елементи

        items.forEach(item => {
            const option = document.createElement('option');
            option.value = item.id;
            option.textContent = item.name;
            dropdown.appendChild(option);
        });
    } catch (error) {
        console.error(`Error loading components: ${error.message}`);
    }
}

// Виклики для завантаження компонентів
loadComponents('/api/Cases', 'case-dropdown');
loadComponents('/api/Motherboards', 'motherboard-dropdown');
loadComponents('/api/Processors', 'processor-dropdown');
loadComponents('/api/Gpus', 'gpu-dropdown');
loadComponents('/api/CpuCoolers', 'cpu-cooler-dropdown');
loadComponents('/api/Rams', 'ram-dropdown');
loadComponents('/api/Memories', 'memory-dropdown');
loadComponents('/api/PowerSupplies', 'power-supply-dropdown');


*/


async function loadComponents(url, dropdownId) {
    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.json();
        const items = data.$values;

        if (!Array.isArray(items)) {
            throw new Error('Response is not an array');
        }

        const dropdown = document.getElementById(dropdownId);
        dropdown.innerHTML = ''; // Clear previous options

        // Add empty option
        const emptyOption = document.createElement('option');
        emptyOption.value = '';
        emptyOption.textContent = '';
        dropdown.appendChild(emptyOption);

        items.forEach(item => {
            const option = document.createElement('option');
            option.value = item.id;
            option.textContent = item.name;
            dropdown.appendChild(option);
        });
    } catch (error) {
        console.error(`Error loading components: ${error.message}`);
    }
}

async function updateDetails(detailsId, dropdownId) {
    const dropdown = document.getElementById(dropdownId);
    const selectedId = dropdown.value;

    if (!selectedId) {
        document.getElementById(detailsId).textContent = '';
        updateTotalPrice();
        return;
    }

    try {
        const response = await fetch(`/api/${dropdownId.split('-')[0]}s/${selectedId}`);
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const item = await response.json();
        document.getElementById(detailsId).textContent = `
            Name: ${item.name}
            Price: $${item.price}
            Description: ${item.description}
            Power Demand: ${item.powerDemand}W
        `;
        updateTotalPrice();
    } catch (error) {
        console.error(`Error loading details: ${error.message}`);
    }
}

async function updateTotalPrice() {
    const dropdownIds = [
        'case-dropdown',
        'motherboard-dropdown',
        'processor-dropdown',
        'gpu-dropdown',
        'cpu-cooler-dropdown',
        'ram-dropdown',
        'memory-dropdown',
        'power-supply-dropdown'
    ];

    let totalPrice = 0;

    for (const dropdownId of dropdownIds) {
        const dropdown = document.getElementById(dropdownId);
        const selectedId = dropdown.value;

        if (selectedId) {
            try {
                const response = await fetch(`/api/${dropdownId.split('-')[0]}s/${selectedId}`);
                if (response.ok) {
                    const item = await response.json();
                    totalPrice += item.price;
                }
            } catch (error) {
                console.error(`Error loading price: ${error.message}`);
            }
        }
    }

    document.getElementById('total-price').textContent = `Total Price: $${totalPrice}`;
}

function addComponent(event) {
    event.preventDefault(); // Prevent page reload on form submit
    updateTotalPrice();
}

// Load components into dropdowns
loadComponents('/api/Cases', 'case-dropdown');
loadComponents('/api/Motherboards', 'motherboard-dropdown');
loadComponents('/api/Processors', 'processor-dropdown');
loadComponents('/api/Gpus', 'gpu-dropdown');
loadComponents('/api/CpuCoolers', 'cpu-cooler-dropdown');
loadComponents('/api/Rams', 'ram-dropdown');
loadComponents('/api/Memories', 'memory-dropdown');
loadComponents('/api/PowerSupplies', 'power-supply-dropdown');

// Add event listener for form submission
document.querySelector('form').addEventListener('submit', addComponent);


function populateDropdown(component, items) {
    const dropdown = document.getElementById(component);
    items.forEach(item => {
        const option = document.createElement('option');
        option.value = item.id;
        option.textContent = item.name;
        dropdown.appendChild(option);
    });
}

function updateDetails(component) {
    const selectedId = document.getElementById(component).value;
    const item = components[component].find(i => i.id == selectedId);
    componentDetails[component] = item;
    displayDetails(item);
    updateSummary();
}

function displayDetails(item) {
    const detailsDiv = document.getElementById('component-details');
    detailsDiv.innerHTML = '';
    for (let key in item) {
        const detail = document.createElement('div');
        detail.textContent = `${key}: ${item[key]}`;
        detailsDiv.appendChild(detail);
    }
}

function updateSummary() {
    const summaryDiv = document.getElementById('build-summary');
    summaryDiv.innerHTML = '';
    let totalPrice = 0;
    for (let component in componentDetails) {
        const item = componentDetails[component];
        if (item && item.price) {
            totalPrice += item.price;
            const summaryItem = document.createElement('div');
            summaryItem.textContent = `${component}: ${item.name} - $${item.price}`;
            summaryDiv.appendChild(summaryItem);
        }
    }
    const totalDiv = document.createElement('div');
    totalDiv.textContent = `Total Price: $${totalPrice}`;
    summaryDiv.appendChild(totalDiv);
}


document.addEventListener('DOMContentLoaded', function () {
    const caseDropdown = document.getElementById('case-dropdown');
    const motherboardDropdown = document.getElementById('motherboard-dropdown');
    const processorDropdown = document.getElementById('processor-dropdown');
    const gpuDropdown = document.getElementById('gpu-dropdown');
    const cpuCoolerDropdown = document.getElementById('cpu-cooler-dropdown');
    const ramDropdown = document.getElementById('ram-dropdown');
    const memoryDropdown = document.getElementById('memory-dropdown');
    const powerSupplyDropdown = document.getElementById('power-supply-dropdown');

    const caseDetails = document.getElementById('case-details');
    const motherboardDetails = document.getElementById('motherboard-details');
    const processorDetails = document.getElementById('processor-details');
    const gpuDetails = document.getElementById('gpu-details');
    const cpuCoolerDetails = document.getElementById('cpu-cooler-details');
    const ramDetails = document.getElementById('ram-details');
    const memoryDetails = document.getElementById('memory-details');
    const powerSupplyDetails = document.getElementById('power-supply-details');

    caseDropdown.addEventListener('change', () => displayComponentDetails('Case',caseDropdown.value, caseDetails));
    motherboardDropdown.addEventListener('change', () => displayComponentDetails('Motherboard', motherboardDropdown.value, motherboardDetails));
    processorDropdown.addEventListener('change', () => displayComponentDetails('Processor', processorDropdown.value, processorDetails));
    gpuDropdown.addEventListener('change', () => displayComponentDetails('Gpu', gpuDropdown.value, gpuDetails));
    cpuCoolerDropdown.addEventListener('change', () => displayComponentDetails('CPUCooler', cpuCoolerDropdown.value, cpuCoolerDetails));
    ramDropdown.addEventListener('change', () => displayComponentDetails('Ram', ramDropdown.value, ramDetails));
    memoryDropdown.addEventListener('change', () => displayComponentDetails('Memory', memoryDropdown.value, memoryDetails));
    powerSupplyDropdown.addEventListener('change', () => displayComponentDetails('PowerSupply', powerSupplyDropdown.value, powerSupplyDetails));
});

async function displayComponentDetails(componentType, componentId, detailsElement) {
    try {
        const response = await fetch(`/api/${componentType}s/${componentId}`);
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const componentDetails = await response.json();

        // Тут ви можете оновити detailsElement з отриманими даними про компонент

        if (componentType == 'Case') {

            detailsElement.innerHTML = `
             <p>======= Case=======</p>
            <p>Name: ${componentDetails.name}</p>
             <p>formfactor: ${componentDetails.brand.name}</p>
            <p>Price: $${componentDetails.price}</p>
            <p>Description: ${componentDetails.description}</p>
             <p>formfactor: ${componentDetails.formFactor.name}</p>

            <!-- Додайте інші характеристики за необхідності -->

        `;
        }

        if (componentType == 'Motherboard') {

            detailsElement.innerHTML = `
             <p>======= Case=======</p>
            <p>Name: ${componentDetails.name}</p>
            <p>Brand: ${componentDetails.brand.name}</p>
            <p>Price: $${componentDetails.price}</p>
            <p>Description: ${componentDetails.description}</p>
            <p>formfactor: ${componentDetails.formFactor.name}</p>
            <p>Processor Socket: ${componentDetails.processorSocket.name}</p>
            <p>GPU Socket: ${componentDetails.gpuSocket.name}</p>
            <p>Max RAM capacity: ${componentDetails.maxRamCapacity} GB</p>
            <p>Max RAM speed: ${componentDetails.maxRamSpeed}</p>
            <p>chipset: ${componentDetails.chipset}</p>
            <p>Power demand: ${componentDetails.powerDemand} W</p>

            <!-- Додайте інші характеристики за необхідності -->

        `;
        }

        if (componentType == 'Processor') {

            detailsElement.innerHTML = `
             <p>======= Case =======</p>
            <p>Name: ${componentDetails.name}</p>
            <p>Brand: ${componentDetails.brand.name}</p>
            <p>Price: $${componentDetails.price}</p>
            <p>Description: ${componentDetails.description}</p>
            <p>Processor Socket: ${componentDetails.processorSocket.name}</p>
            <p>Max RAM capacity: ${componentDetails.maxRAMCapacity} GB</p>
            <p>Speed: ${componentDetails.speed} GH</p>
            <p>N cores: ${componentDetails.ncores}</p>
            <p>Power demand: ${componentDetails.powerDemand} W</p>

            <!-- Додайте інші характеристики за необхідності -->

        `;
        }

        if (componentType == 'Gpu') {

            detailsElement.innerHTML = `
             <p>======= GPU =======</p>
            <p>Name: ${componentDetails.name}</p>
            <p>Brand: ${componentDetails.brand.name}</p>
            <p>Price: $${componentDetails.price}</p>
            <p>Description: ${componentDetails.description}</p>
            <p>formfactor: ${componentDetails.formFactor.name}</p>
            <p>GPU Socket: ${componentDetails.gpuSocket.name}</p>
            <p>VRAM: ${componentDetails.vram}</p>
            <p>Power demand: ${componentDetails.powerDemand} W</p>

            <!-- Додайте інші характеристики за необхідності -->

        `;
        }

        if (componentType == 'CPUCooler') {

            detailsElement.innerHTML = `
             <p>======= CPU Cooler =======</p>
            <p>Name: ${componentDetails.name}</p>
            <p>Brand: ${componentDetails.brand.name}</p>
            <p>Price: $${componentDetails.price}</p>
            <p>Description: ${componentDetails.description}</p>
            <p>Power demand: ${componentDetails.powerDemand} W</p>

            <!-- Додайте інші характеристики за необхідності -->

        `;
        }

        if (componentType == 'Ram') {

            detailsElement.innerHTML = `
             <p>======= Ram =======</p>
            <p>Name: ${componentDetails.name}</p>
            <p>Brand: ${componentDetails.brand.name}</p>
            <p>Price: $${componentDetails.price}</p>
            <p>Description: ${componentDetails.description}</p>
            <p>Power demand: ${componentDetails.powerDemand} W</p>
            <p>Speed: ${componentDetails.speed} GH</p>
            <p>Capacity: ${componentDetails.capacity}</p>
            <!-- Додайте інші характеристики за необхідності -->

        `;

        }

        if (componentType == 'Memory') {

            detailsElement.innerHTML = `
             <p>======= Memory =======</p>
            <p>Name: ${componentDetails.name}</p>
            <p>Brand: ${componentDetails.brand.name}</p>
            <p>Price: $${componentDetails.price}</p>
            <p>Description: ${componentDetails.description}</p>
            <p>Capacity: ${componentDetails.capacity}</p>
            <p>Type: ${componentDetails.type}</p>
            <!-- Додайте інші характеристики за необхідності -->

        `;
        }

        if (componentType == 'PowerSupply') {

            detailsElement.innerHTML = `
             <p>======= PowerSupply =======</p>
            <p>Name: ${componentDetails.name}</p>
            <p>Brand: ${componentDetails.brand.name}</p>
            <p>Price: $${componentDetails.price}</p>
            <p>Description: ${componentDetails.description}</p>
            <p>Power: ${componentDetails.power} W</p>
            <!-- Додайте інші характеристики за необхідності -->

        `;
        }
    }
    catch (error) {
        console.error(`Error loading component details: ${error.message}`);
        detailsElement.innerHTML = `No component selected`;
    }
}


