# SauceDemo Login Form Automated Tests

This project implements UI automated tests for the login form of [SauceDemo](https://www.saucedemo.com/).

---

## 📋 Original Task Description

> **Launch URL**: https://www.saucedemo.com/  
>
> **UC-1 Test Login form with empty credentials**:  
> Type any credentials into "Username" and "Password" fields.  
> Clear the inputs.  
> Hit the "Login" button.  
> Check the error messages: **"Username is required"**.  
>
> **UC-2 Test Login form with credentials by passing Username**:  
> Type any credentials in username.  
> Enter password.  
> Clear the "Password" input.  
> Hit the "Login" button.  
> Check the error messages: **"Password is required"**.  
>
> **UC-3 Test Login form with credentials by passing Username & Password**:  
> Type credentials in username which are under Accepted username section.  
> Enter password as **secret_sauce**.  
> Click on Login and validate the title **“Swag Labs”** in the dashboard.  
>
> Provide **parallel execution**, add **logging** for tests and use **Data Provider** to **parametrize tests**.  
> Make sure that all tasks are supported by these 3 conditions: **UC-1; UC-2; UC-3**.  
>
> To perform the task use the various additional options:  
> - **Test Automation tool**: Selenium WebDriver  
> - **Browsers**: Edge, Firefox  
> - **Locators**: XPath  
> - **Test Runner**: MSTest  
> - [Optional] **Patterns**: Builder, Adapter, Bridge  
> - [Optional] **Test automation approach**: BDD  
> - **Assertions**: Fluent Assertion  
> - [Optional] **Loggers**: NLog

---

## ✅ Use Cases

### UC-1: Test Login Form with Empty Credentials
- Type any credentials into "Username" and "Password" fields.
- Clear the inputs.
- Hit the "Login" button.
- Check the error message: **"Username is required"**.

### UC-2: Test Login Form with Missing Password
- Type any credentials in username.
- Enter password.
- Clear the "Password" input.
- Hit the "Login" button.
- Check the error message: **"Password is required"**.

### UC-3: Test Login Form with Valid Credentials
- Type credentials in username from the "Accepted usernames" section.
- Enter password: **"secret_sauce"**.
- Click on Login.
- Validate the title: **"Swag Labs"**.

---

## 🛠 Technical Stack

- **Test Automation Tool**: Selenium WebDriver  
- **Browsers**: Edge, Firefox  
- **Locators**: XPath  
- **Test Runner**: MSTest  
- **Assertions**: Fluent Assertions  

---

## 📌 Additional Conditions

- Provide **parallel execution**  
- Add **logging for tests**  
- Use **Data Provider** to parameterize tests  
- All tasks (UC-1, UC-2, UC-3) must be supported by these features  

---

## [Optional]

- **Design Patterns**: Builder, Adapter, Bridge  
- **Test Automation Approach**: BDD  
- **Logger**: NLog