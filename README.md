<h1>Introduction</h1>
<p>
  This MVC .Net Core app is written as part of the application process for a role at Direct Ferries. 
</p>
<h1>Requirement</h1>
<p>Table below summarizes the requirements and elaborates each with interpretation as basis for development.</p>
<table>
  <tr>
    <th>Requirement</th>
    <th>Interpretation</th>
  </tr>
  <tr>
    <td>Ask user to enter full name, dob</td>
    <td>User requires to enter their full name disregarding the prefix, suffix and title. The full name will be a single variable when being read (not separated for name and surname). The date of birth will be also read separately.</td>
  </tr>
  <tr>
    <td>Redirect the user to another page on submission</td>
    <td>The concept of redirection in HTTP is performed only via GET protocol. In Razor RedirectToPage could be used. In MVC (this project) RedirectToAction is used instead to perform the same process on submitting the form</td>
  </tr>
  <tr>
    <td>Display welcome message with users first name only</td>
    <td>The first name needs to be extracted from the full name and therefore require further validation to ensure the input in the first step is actually a valid Full Name.</td>
  </tr>
  <tr>
    <td>Display message showing how many vowels are in the name</td>
    <td>The name above could refer to both full name and first name. Since on a Welcome message a first name is more approperite, the extracted first name is used.</td>
  </tr>
  <tr>
    <td>Display message showing how many vowels are in the name</td>
    <td>The name above could refer to both full name and first name. Since on a Welcome message a first name is more approperite, the extracted first name is used. It's also assumed that the vowels should be counted regardless of any repeatition</td>
  </tr>
  <tr>
    <td>Display message showing how old the user is and how many days before next birthday.</td>
    <td>Based on the DOB, the users' age is calculated, taken into account the leap years. Similarly number of days to their birthday is calculated.</td>
  </tr>
  <tr>
    <td>Show table which displays 14 days before run up to next birthday (days of week (mon, tue, wed etc..) and allow the dates to be clickable, which redirect the user to the following “https://www.historynet.com/today-in-history/june-10” with selected date
    </td>
    <td>
      A small two-row calendar will be shown in the result page. Showing day and month in each cell. The cells will appear in chronological order, showing the oldest time on the left top corner. Since, no post-processing is required on the click, each cell can directly link to the required page without creating further load on the server.
    </td>
  </tr>
</table>

<h1>Services</h1>
<h2>Configuration</h2>
<p>The app config will be read from appsettings.json where the number of weeks to be shown before the birthday can be adjusted. The config service does not depend on other inputs and would be more handy to be injected to the page in a Razor fashion.</p>
<h2>Validation</h2>
<h3>Backend</h3>
<p>MVC provides basic model validation based on the types and attributes. A Validation service was created to ensure the validity of the First Name and DOB when taken in the first page.</p>
<h3>Frontent</h3>
<p>RegExp was used to allow only alphabets and blank space in the Full Name field.</p>
<h2>User Processor</h2> 
<p>The user processor is responsible for creating the result model based on the unser input. This process could be done within the UserInfo model itself, however, having this separated as a sesrvice will have several benefits in code maintanance and extending the code as well avoiding server load when these computations are not necessary in the processes of user input</p>
