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
</table>
