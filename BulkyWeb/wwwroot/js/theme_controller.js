// Get the theme controller elements
const themeControllers = document.querySelectorAll('.theme-controller');

// Function to handle theme change
function changeTheme(event) {
    const theme = event.target.value;

    // Apply the selected theme
    document.documentElement.setAttribute('data-theme', theme);

    // Store the selected theme in local storage
    localStorage.setItem('selectedTheme', theme);
}

// Add event listener to each theme controller
themeControllers.forEach(controller => {
    controller.addEventListener('change', changeTheme);
});

// Apply the stored theme when the page loads
window.addEventListener('load', () => {
    const selectedTheme = localStorage.getItem('selectedTheme');
    if (selectedTheme) {
    document.documentElement.setAttribute('data-theme', selectedTheme);

    // Check the corresponding radio button
    const selectedRadioButton = document.querySelector(`input[value="${selectedTheme}"]`);
    if (selectedRadioButton) {
        selectedRadioButton.checked = true;
    }
    }
});