
## Typescript Sample

Certainly! Below is an example of a simple Node.js application written in TypeScript. This example uses axios to make an HTTP request to a sample API.

1. Initialize a TypeScript Project:

If you don't have a TypeScript project set up, you can create one by running the following commands in your terminal:

```bash
mkdir my-ts-app
cd my-ts-app
npm init -y
npm install typescript
npx tsc --init
```


2. Install Dependencies:

Install the axios library for making HTTP requests:
```bash
npm install axios
```

3. Create TypeScript Files:

Create a file named app.ts in your project directory and add the following code:
typescript

```typescript
// app.ts
import axios from 'axios';

const apiUrl = 'https://jsonplaceholder.typicode.com/posts/1';

async function fetchData() {
    try {
        const response = await axios.get(apiUrl);
        console.log('Data from API:', response.data);
    } catch (error) {
        console.error('Error fetching data:', error.message);
    }
}

// Call the fetchData function
fetchData();
```

4. Compile and Run:

Compile the TypeScript code using the TypeScript compiler:

```bash
npx tsc
```

This will generate a dist directory with the compiled JavaScript files.
Run the application:
```bash
node dist/app.js
```

You should see the data fetched from the API logged to the console.
