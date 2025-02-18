# VisaPro Application

A web application for processing customer orders with various discounts based on customer type.

## Features

- **Order Amount Input**: Users can input their order amount.
- **Customer Type Selection**: Choose between "New" or "Loyal" customer for different discount rates.
- **Discount Calculation**: Calculates discounts based on amount and customer type.
- **User Interface**: Styled with Bootstrap for a responsive and pleasant user experience.
- **Validation**: Client-side and server-side input validation for error-free user interactions.
- **Testing**: Unit tests implemented using xUnit for robust code verification.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Installation

1. **Clone the Repository**

   ```sh
   git clone https://github.com/Muhanned7/VisaPro.git
   cd visapro

2. **Restore Dependencies**
Ensure you have the .NET SDK installed, then restore the project dependencies:
sh
dotnet restore


3. **Build the Application**
Build the application to ensure all code compiles:
sh
dotnet build
4. **Run the Application**
Start the application in development mode:
sh
dotnet run --project VisaPro

5. **Running Tests**
To run the unit tests:

sh
dotnet test
### CI/CD

**Continuous Integration (CI):**

- **Automated Testing**: Whenever you make a commit to your feature branch, GitHub Actions will automatically run the unit tests on that branch. This ensures that new code doesn't break existing functionality.

  - **Trigger**: On every `push` to a feature branch.
  - **Actions**:
    - Run `dotnet restore` to fetch dependencies.
    - Execute `dotnet build` to compile the project.
    - Perform `dotnet test` to run the unit tests.

**Continuous Deployment (CD):**

- **Manual Merge**: After a successful build and test run, there's no automatic merge into the `master` or `main` branch. Instead:
  - **Review**: A pull request (PR) should be created for manual review before merging. This step ensures that changes are scrutinized by team members or maintainers.
  - **Merge**: Once the PR has been reviewed and approved, the merge can be manually performed. This approach allows for human oversight to catch any issues that automated tests might not detect.
