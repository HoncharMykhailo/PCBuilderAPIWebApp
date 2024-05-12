const uri = 'api/formFactors';
let formFactors = [];

function getFormFactors() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayFormFactors(data))
        .catch(error => console.error('Unable to get formFactors.', error));
}
/*
function addFormFactor() {
    const addNameTextbox = document.getElementById('add-name');
    const addInfoTextbox = document.getElementById('add-sizeCoefficient');

    const formFactor = {
        name: addNameTextbox.value.trim(),
        info: addInfoTextbox.value.trim(),
    };
    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formFactor)
    })
        .then(response => response.json())
        .then(() => {
            getFormFactors();
            addNameTextbox.value = '';
            addInfoTextbox.value = '';
        })
        .catch(error => console.error('Unable to add form factor.', error));
}

function deleteFormFactor(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getFormFactors())
        .catch(error => console.error('Unable to delete form factor.', error));
}

function displayEditForm(id) {
    const formFactor = formFactors.find(formFactor => formFactor.id === id);

    document.getElementById('edit-id').value = formFactor.id;
    document.getElementById('edit-name').value = formFactor.name;
    document.getElementById('edit-sizeCoefficient').value = formFactor.SizeCoefficient;
    document.getElementById('editForm').style.display = 'block';
}

function updateFormFactor() {
    const formFactorId = document.getElementById('edit-id').value;
    const formFactor = {
        id: parseInt(formFactorId, 10),
        name: document.getElementById('edit-name').value.trim(),
        info: document.getElementById('edit-sizeCoefficient').value.trim()
    };

    fetch(`${uri}/${formFactorId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formFactor)
    })
        .then(() => getFormFactors())
        .catch(error => console.error('Unable to update formFactor.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayFormFactors(data) {
    const tBody = document.getElementById('formFactors');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(formFactor => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${formFactor.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteFormFactor(${formFactor.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(formFactor.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(formFactor.sizeCoefficient);
        td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    formFactors = data;
}
*/


        function addFormFactor() {
    const addNameTextbox = document.getElementById('add-name');
    const addInfoTextbox = document.getElementById('add-sizeCoefficient');

    const formFactor = {
        name: addNameTextbox.value.trim(),
        sizeCoefficient: parseInt(addInfoTextbox.value.trim(), 10)  // Convert to integer
    };
    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formFactor)
    })
        .then(response => response.json())
        .then(() => {
            getFormFactors();
            addNameTextbox.value = '';
            addInfoTextbox.value = '';
        })
        .catch(error => console.error('Unable to add form factor.', error));
}


function deleteFormFactor(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getFormFactors())
        .catch(error => console.error('Unable to delete form factor.', error));
}

function displayEditForm(id) {
    const formFactor = formFactors.find(formFactor => formFactor.id === id);

    document.getElementById('edit-id').value = formFactor.id;
    document.getElementById('edit-name').value = formFactor.name;
    document.getElementById('edit-sizeCoefficient').value = formFactor.SizeCoefficient;
    document.getElementById('editForm').style.display = 'block';
}


function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}




function updateFormFactor() {
    const formFactorId = document.getElementById('edit-id').value;
    const formFactor = {
        id: parseInt(formFactorId, 10),
        name: document.getElementById('edit-name').value.trim(),
        sizeCoefficient: parseInt(document.getElementById('edit-sizeCoefficient').value.trim(), 10)  // Convert to integer
    };

    fetch(`${uri}/${formFactorId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formFactor)
    })
        .then(() => getFormFactors())
        .catch(error => console.error('Unable to update formFactor.', error));

    closeInput();

    return false;
}

function _displayFormFactors(data) {
    const tBody = document.getElementById('formFactors');
    tBody.innerHTML = '';

    data.forEach(formFactor => {
        let editButton = document.createElement('button');
        editButton.innerText = 'Edit';
        editButton.addEventListener('click', () => displayEditForm(formFactor.id));

        let deleteButton = document.createElement('button');
        deleteButton.innerText = 'Delete';
        deleteButton.addEventListener('click', () => deleteFormFactor(formFactor.id));

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(formFactor.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(formFactor.sizeCoefficient);  // Display as integer
        td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    formFactors = data;
}