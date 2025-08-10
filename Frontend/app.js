const addPayment = () =>{
    const amount = document.getElementById("amount").value;

    fetch("https://localhost:32769/api/Payments", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({amountPaid: amount, clientId: 6})
    })
    .then(response => response.json())
    .then(data => {
        console.log(`Date of payment ${data.dateOfPayment}`)
        console.log(`Amount paid ${data.amountPaid}`)
    })

}

const getBalance = async () =>{
    const clientId = document.getElementById("balanceId").value;

    const response = await fetch(`https://localhost:32769/api/Balances/${clientId}`, {
        method: "GET",
    });

    const data = await response.json();

    displayBalance(data);
    // .then(response => response.json())
    // .then(data => {
    //     console.log(`Balance ${data.balanceAmount}`)
    //     console.log(`Valid ${data.validUntil}`)
}

const displayBalance = (data) =>{
    document.getElementById("balance-result").innerHTML = 
    `
        <h2>Balance: ${data.balanceAmount}</h2>
        <p>Valid: ${data.validUntil}</p>
        <p>Status: ${data.balanceAmount >= 0 ? "Brak zaległości" : "Zalegasz :("}</p>
    `;
}