// Get the current date in ISO format (YYYY-MM-DD)
const currentDate = new Date().toISOString().split('T')[0];
// Set the min attribute of the CheckIn input field to prevent selection of past dates
document.getElementById("CheckIn").min = currentDate;

// Add an event listener to the CheckIn input to dynamically set the min attribute of CheckOut input
document.getElementById("CheckIn").addEventListener("change", function () {
    const checkInDate = new Date(this.value);
    const minCheckOutDate = new Date(checkInDate);
    minCheckOutDate.setDate(checkInDate.getDate() + 1); // Minimum CheckOut date is the day after CheckIn
    const minCheckOutDateISO = minCheckOutDate.toISOString().split('T')[0];
    document.getElementById("CheckOut").min = minCheckOutDateISO;

    // Reset the CheckOut date when a new CheckIn date is chosen
    document.getElementById("CheckOut").value = "";
});
