const enrollment = () => {
    const register = document.querySelector(`.register-section`)
    register.style.display = 'block';
}

const register = async () => {
    const data = {
        email: document.querySelector(`.email input`).value,
        firstName: document.querySelector(`.firstname input`).value,
        lastName: document.querySelector(`.lastname input`).value,
        password: document.querySelector(`.password input`).value
    }

    try {
        const response = await fetch('api/User', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        })

        if (response.ok)
            alert("User succsesfuly added")
        else
            throw new ("Error, try again")
    }
    catch (e) {
        alert(e.message)
    }
}

const login = async () => {
    const postData = {
        l_email: document.querySelector(".l_email input").value,
        l_password: document.querySelector(".l_password input").value,
    }

    try {
        const response = await fetch('api/User/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(postData)
        })

        if (response.ok) {
            const dataUser = await response.json()
            sessionStorage.setItem("dataUser",JSON.stringify(dataUser))
            window.location.href='update.html'
        }
        else {
            throw new ("some error:(")
        }
    }
    catch (e) {
        alert(e.message)
    }
}