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
          //  try {

                let api;
                switch (dropdownId.split('-')[0]) {
                    case 'memory':
                        api = `/api/Memories/${selectedId}`;
                        break;
                    case 'power':
                        api = `/api/PowerSupplies/${selectedId}`;
                        break;
                    case 'cpu':
                        api = `/api/CPUCoolers/${selectedId}`;
                        break;
                    default:
                        api = `/api/${dropdownId.split('-')[0]}s/${selectedId}`;
                }



                const response = await fetch(api);


                if (response.ok) {
                    const item = await response.json();
                    totalPrice += item.price;
                }
         //   } catch (error) {
         //       console.error(`Error loading price: ${error.message}`);
          //  }
        }
        else {
           // alert("Not every component was chosen");
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

    caseDropdown.addEventListener('change', () => {
        if (caseDropdown.value == "") {
         /*   caseDetails.innerHTML = `======= No Case Selected =========`;
            motherboardDetails.innerHTML = `======= No Motherboard Selected =========`;
            processorDetails.innerHTML = `======= No Processor Selected =========`;
            gpuDetails.innerHTML = `======= No GPU Selected =========`;
            cpuCoolerDetails.innerHTML = `======= No CPU cooler Selected =========`;
            ramDetails.innerHTML = `======= No RAM Selected =========`;
            memoryDetails.innerHTML = `======= No Memory Selected =========`;
            powerSupplyDetails.innerHTML = `======= No Power Supply Selected =========`;*/

            caseDetails.innerHTML = `-`;
            motherboardDetails.innerHTML = `-`;
            processorDetails.innerHTML = `-`;
            gpuDetails.innerHTML = `-`;
            cpuCoolerDetails.innerHTML = `-`;
            ramDetails.innerHTML = `-`;
            memoryDetails.innerHTML = `-`;
            powerSupplyDetails.innerHTML = `-`;
        }
        displayComponentDetails('Case', caseDropdown.value, caseDetails)
    });

    
    motherboardDropdown.addEventListener('change', () => {
        if (motherboardDropdown.value == "") {
          /*  motherboardDetails.innerHTML = `======= No Motherboard Selected =========`;
            processorDetails.innerHTML = `======= No Processor Selected =========`;
            gpuDetails.innerHTML = `======= No GPU Selected =========`;
            cpuCoolerDetails.innerHTML = `======= No CPU cooler Selected =========`;
            ramDetails.innerHTML = `======= No RAM Selected =========`;
            memoryDetails.innerHTML = `======= No Memory Selected =========`;
            powerSupplyDetails.innerHTML = `======= No Power Supply Selected =========`;*/

            motherboardDetails.innerHTML = `-`;
            processorDetails.innerHTML = `-`;
            gpuDetails.innerHTML = `-`;
            cpuCoolerDetails.innerHTML = `-`;
            ramDetails.innerHTML = `-`;
            memoryDetails.innerHTML = `-`;
            powerSupplyDetails.innerHTML = `-`;
        }
       
        displayComponentDetails('Motherboard', motherboardDropdown.value, motherboardDetails)
    });
    processorDropdown.addEventListener('change', () => {
        if (processorDropdown.value == "") {/*
            processorDetails.innerHTML = `======= No Processor Selected =========`;
            gpuDetails.innerHTML = `======= No GPU Selected =========`;
            cpuCoolerDetails.innerHTML = `======= No CPU cooler Selected =========`;
            ramDetails.innerHTML = `======= No RAM Selected =========`;
            memoryDetails.innerHTML = `======= No Memory Selected =========`;
            powerSupplyDetails.innerHTML = `======= No Power Supply Selected =========`;*/



            processorDetails.innerHTML = `-`;
            gpuDetails.innerHTML = `-`;
            cpuCoolerDetails.innerHTML = `-`;
            ramDetails.innerHTML = `-`;
            memoryDetails.innerHTML = `-`;
            powerSupplyDetails.innerHTML = `-`;
        }
        displayComponentDetails('Processor', processorDropdown.value, processorDetails)
    });
    gpuDropdown.addEventListener('change', () => {
        if (gpuDropdown.value == "") {
            gpuDetails.innerHTML = `-`;
            powerSupplyDetails.innerHTML = `-`;
        }
        displayComponentDetails('Gpu', gpuDropdown.value, gpuDetails)
    });
    cpuCoolerDropdown.addEventListener('change', () => {
        if (cpuCoolerDropdown.value == "") {
            cpuCoolerDetails.innerHTML = `-`;
            powerSupplyDetails.innerHTML = `-`;
        }
        displayComponentDetails('CPUCooler', cpuCoolerDropdown.value, cpuCoolerDetails)
    });
    ramDropdown.addEventListener('change', () => {
        if (ramDropdown.value == "") {
            ramDetails.innerHTML = `-`;
            powerSupplyDetails.innerHTML = `-`;
        }
        displayComponentDetails('Ram', ramDropdown.value, ramDetails)
    });
    memoryDropdown.addEventListener('change', () => {
        if (memoryDropdown.value == "") {
            memoryDetails.innerHTML = `-`;
            powerSupplyDetails.innerHTML = `-`;
        }
        displayComponentDetails('Memory', memoryDropdown.value, memoryDetails)
    });
    powerSupplyDropdown.addEventListener('change', () => {
        if (powerSupplyDropdown.value == "") {
            powerSupplyDetails.innerHTML = `-`;
        }
        displayComponentDetails('PowerSupply', powerSupplyDropdown.value, powerSupplyDetails)
    });
});

async function displayComponentDetails(componentType, componentId, detailsElement) {
    let apiEndpoint;


    // Визначаємо правильний endpoint на основі componentType
    switch (componentType) {
        case 'Memory':
            apiEndpoint = `/api/Memories/${componentId}`;
            break;
        case 'PowerSupply':
            apiEndpoint = `/api/PowerSupplies/${componentId}`;
            break;
        default:
            apiEndpoint = `/api/${componentType}s/${componentId}`;
    }

    if (componentType == 'Case') {

        detailsElement.innerHTML = `-`;
    }
    if (componentType == 'Motherboard') {

        detailsElement.innerHTML = `-`;
    }
    if (componentType == 'Processor') {

        detailsElement.innerHTML = `-`;
    }
    if (componentType == 'Gpu') {

        detailsElement.innerHTML = `-`;
    }
    if (componentType == 'CpuCooler') {

        detailsElement.innerHTML = `-`;
    }
    if (componentType == 'Memory') {

        detailsElement.innerHTML = `-`;
    }
    if (componentType == 'PowerSupply') {

        detailsElement.innerHTML = `-`;
    }
  


    try {


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



        const response = await fetch(apiEndpoint);
           

        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const componentDetails = await response.json();

        if (componentType == 'Case') {


    


            detailsElement.innerHTML = `
            <p>Case:</p>
            <p>Name: ${componentDetails.name}</p>
            <p>formfactor: ${componentDetails.brand.name}</p>
            <p>Price: $${componentDetails.price}</p>
            <p>Description: ${componentDetails.description}</p>
            <p>formfactor: ${componentDetails.formFactor.name}</p>

        `;
            motherboardDetails.innerHTML = `Motherboard: -`;
        }

        if (componentType == 'Motherboard') {



            let caseResponse = await fetch(`/api/Cases/${caseDropdown.value}`);
            let caseDet = await caseResponse.json();
            let caseFF = caseDet.formFactor.sizeCoefficient;
            if (caseFF < componentDetails.formFactor.sizeCoefficient) {
              //  alert(`This Motherboard is too big`)
                detailsElement.innerHTML = `This Motherboard is too big`;
            }
            else {
                detailsElement.innerHTML = `
                 <p>Motherboard: </p>
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
                `;
        
            }
        }

        if (componentType == 'Processor') {




            let motherboardResponse = await fetch(`/api/Motherboards/${motherboardDropdown.value}`);
            let motherboardDet = await motherboardResponse.json();
            let motherboardSocket = motherboardDet.processorSocket.id;
            if (motherboardSocket != componentDetails.processorSocket.id) {
                detailsElement.innerHTML = `This CPU is incompatable with your motherboard `;
            }
            else {

                detailsElement.innerHTML = `
             <p>Processor":"</p>
            <p>Name: ${componentDetails.name}</p>
            <p>Brand: ${componentDetails.brand.name}</p>
            <p>Price: $${componentDetails.price}</p>
            <p>Description: ${componentDetails.description}</p>
            <p>Processor Socket: ${componentDetails.processorSocket.name}</p>
            <p>Max RAM capacity: ${componentDetails.maxRAMCapacity} GB</p>
            <p>Speed: ${componentDetails.speed} GH</p>
            <p>N cores: ${componentDetails.ncores}</p>
            <p>Power demand: ${componentDetails.powerDemand} W</p>


        `;
            }
        }

        if (componentType == 'Gpu') {


            let motherboardResponse = await fetch(`/api/Motherboards/${motherboardDropdown.value}`);
            let motherboardDet = await motherboardResponse.json();
            let motherboardSocket = motherboardDet.gpuSocket.id;

            let caseResponse = await fetch(`/api/Cases/${caseDropdown.value}`);
            let caseDet = await caseResponse.json();
            let caseFF = caseDet.formFactor.sizeCoefficient;

            if (motherboardSocket != componentDetails.gpuSocket.id || caseFF < componentDetails.formFactor.sizeCoefficient) {

                if (motherboardSocket != componentDetails.gpuSocket.id) {
                    detailsElement.innerHTML = `This GPU is incompatable with your motherboard`;
                }
                if (caseFF < componentDetails.formFactor.sizeCoefficient) {
                    detailsElement.innerHTML = `This GPU is too big`;
                }
               
            }

            else {

                detailsElement.innerHTML = `
             <p>GPU:</p>
            <p>Name: ${componentDetails.name}</p>
            <p>Brand: ${componentDetails.brand.name}</p>
            <p>Price: $${componentDetails.price}</p>
            <p>Description: ${componentDetails.description}</p>
            <p>formfactor: ${componentDetails.formFactor.name}</p>
            <p>GPU Socket: ${componentDetails.gpuSocket.name}</p>
            <p>VRAM: ${componentDetails.vram}</p>
            <p>Power demand: ${componentDetails.powerDemand} W</p>


         `;
            }
        }

        if (componentType == 'CPUCooler') {

            detailsElement.innerHTML = `
             <p>CPU Cooler: </p>
            <p>Name: ${componentDetails.name}</p>
            <p>Brand: ${componentDetails.brand.name}</p>
            <p>Price: $${componentDetails.price}</p>
            <p>Description: ${componentDetails.description}</p>
            <p>Power demand: ${componentDetails.powerDemand} W</p>


        `;
        }

        if (componentType == 'Ram') {


            let processorResponse = await fetch(`/api/Processors/${processorDropdown.value}`);
            let processorDet = await processorResponse.json();
            let processorMaxRam = processorDet.maxRAMCapacity;

            if (processorMaxRam < componentDetails.capacity) {
                detailsElement.innerHTML = `This RAM is incompatable with your CPU `;
            }
            else {

                detailsElement.innerHTML = `
             <p> RAM:</p>
            <p>Name: ${componentDetails.name}</p>
            <p>Brand: ${componentDetails.brand.name}</p>
            <p>Price: $${componentDetails.price}</p>
            <p>Description: ${componentDetails.description}</p>
            <p>Power demand: ${componentDetails.powerDemand} W</p>
            <p>Speed: ${componentDetails.speed} GH</p>
            <p>Capacity: ${componentDetails.capacity}</p>

        `;
            }

        }

        if (componentType == 'Memory') {

            detailsElement.innerHTML = `
             <p>Memory: </p>
            <p>Name: ${componentDetails.name}</p>
            <p>Brand: ${componentDetails.brand.name}</p>
            <p>Price: $${componentDetails.price}</p>
            <p>Description: ${componentDetails.description}</p>
            <p>Capacity: ${componentDetails.capacity}</p>
            <p>Type: ${componentDetails.type}</p>

        `;
        }
        

      



        if (componentType == 'PowerSupply') {


            let motherboardResponse = await fetch(`/api/Motherboards/${motherboardDropdown.value}`);
            let motherboardDet = await motherboardResponse.json();
            let motherboardPD = motherboardDet.powerDemand;

            let coolerResponse = await fetch(`/api/CPUCoolers/${cpuCoolerDropdown.value}`);
            let coolerDet = await coolerResponse.json();
            let coolerPD = coolerDet.powerDemand;

            let processorResponse = await fetch(`/api/Processors/${processorDropdown.value}`);
            let processorDet = await processorResponse.json();
            let processorPD = processorDet.powerDemand;

            let gpuResponse = await fetch(`/api/Gpus/${gpuDropdown.value}`);
            let gpuDet = await gpuResponse.json();
            let gpuPD = gpuDet.powerDemand;

            let ramResponse = await fetch(`/api/rams/${ramDropdown.value}`);
            let ramDet = await ramResponse.json();
            let ramPD = ramDet.powerDemand;

            if (motherboardPD + coolerPD + processorPD + gpuPD + ramPD > componentDetails.power) {
                let sum = motherboardPD + coolerPD + processorPD + gpuPD + ramPD
                detailsElement.innerHTML = `This power supply is too weak for this ` + sum + `W build`;
            }
            else {

                detailsElement.innerHTML = `
             <p> PowerSupply:</p>
            <p>Name: ${componentDetails.name}</p>
            <p>Brand: ${componentDetails.brand.name}</p>
            <p>Price: $${componentDetails.price}</p>
            <p>Description: ${componentDetails.description}</p>
            <p>Power: ${componentDetails.power} W</p>

        `;
            }
        }
    }
    catch (error) {
        console.error(`Error loading component details: ${error.message}`);
      //  detailsElement.innerHTML = `No component selected`;
    }
}


