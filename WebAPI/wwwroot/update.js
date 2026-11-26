const user = JSON.parse(sessionStorage.getItem("dataUser"))

const title = document.querySelector('.title')
title.textContent += ' ' + user.firstName + '!'

const showupdate = () => {
    const register = document.querySelector(`.update`)
    register.style.display = 'block';

    email = document.querySelector(`.email input`)
    email.value = user.email
    firstName = document.querySelector(`.firstname input`)
    firstName.value = user.firstName
    lastName = document.querySelector(`.lastname input`)
    lastName.value = user.lastName
    password = document.querySelector(`.password input`)
    password.value = user.password
}

const update = async () => {
    
    const data = {
        id: user.id,
        email: document.querySelector(`.email input`).value,
        firstName: document.querySelector(`.firstname input`).value,
        lastName: document.querySelector(`.lastname input`).value,
        password: document.querySelector(`.password input`).value
    }

    try {
        const response = await fetch(`api/Users/${user.id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        })
        if (response.ok) {
            alert("The update succsesfuly")
            title.textContent = 'hello ' + data.firstName + '!'
        }
        else {
            const userdata = await response.json()
            throw new Error(userdata)
        }
    }
    catch (e) {
        alert(e.message)
    }
}