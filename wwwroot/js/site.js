// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//js
//
// Get the toast element
const toast = document.getElementById("toast");

// Add a click event listener to remove the toast when clicked
toast.addEventListener("click", function () {
  toast.remove();
});

setTimeout(() => {
  toast.remove();
}, 5000);
