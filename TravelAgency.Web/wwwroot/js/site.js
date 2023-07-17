// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function addImageField() {
    var inputGroup = document.createElement('div');
    inputGroup.className = 'input-group mb-3';

    var input = document.createElement('input');
    input.className = 'form-control';
    input.type = 'text';
    input.name = 'Images[' + (document.querySelectorAll('input[name^="Images["]').length) + ']';
    input.placeholder = 'Image URL...';

    var buttonGroup = document.createElement('div');
    buttonGroup.className = 'input-group-append';

    var removeButton = document.createElement('button');
    removeButton.className = 'btn btn-outline-secondary';
    removeButton.type = 'button';
    removeButton.textContent = '-';
    removeButton.onclick = function () {
        inputGroup.remove();
    };

    buttonGroup.appendChild(removeButton);
    inputGroup.appendChild(input);
    inputGroup.appendChild(buttonGroup);

    document.querySelector('.form-group > .input-group:last-of-type').after(inputGroup);
}

function removeImageField(button) {
    button.closest('.input-group').remove();
}

