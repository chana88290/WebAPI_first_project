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
        const response = await fetch('api/Users', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        })

        if (response.ok)
            alert("User succsesfuly added")
        else {
            const userdata = await response.json()
            throw new Error(userdata)
        }
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
        const response = await fetch('api/Users/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(postData)
        })

        if (response.ok) {
            const dataUser = await response.json()
            sessionStorage.setItem("dataUser", JSON.stringify(dataUser))
            window.location.href = 'update.html'
        }
        else {
            throw new ("some error:(")
        }
    }
    catch (e) {
        alert(e.message)
    }
}

const checkpassword = async () => {
    const password = document.querySelector(`.password input`).value
    try {
        const response = await fetch('api/Passwords', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(password)
        })
        if (response.ok) {
            const progress = document.querySelector(`.progress`)
            progress.value = await response.json()
        }
        else {
            throw new (response.status)
        }
    }
    catch (e) {
        alert(e.message)
    }
}