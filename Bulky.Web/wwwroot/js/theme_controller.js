// Apply the stored theme immediately to prevent flash of light mode
const selectedTheme = localStorage.getItem("selectedTheme");
if (selectedTheme) {
  console.log(`Theme: ${selectedTheme}`);
  document.documentElement.setAttribute("data-theme", selectedTheme);
}

document.addEventListener("DOMContentLoaded", function () {
  const themeControllers = document.querySelectorAll(".theme-controller");

  function changeTheme(event) {
    const theme = event.target.value;
    document.documentElement.setAttribute("data-theme", theme);
    localStorage.setItem("selectedTheme", theme);
  }

  themeControllers.forEach((controller) => {
    controller.addEventListener("change", changeTheme);
  });

  if (selectedTheme) {
    const selectedRadioButton = document.querySelector(
      `input[value="${selectedTheme}"]`,
    );
    if (selectedRadioButton) {
      selectedRadioButton.checked = true;
    }
  }
});
