# Stage 1: Build the React application with Vite
# We use a specific version of Node for reproducibility. 'alpine' is a lightweight version.
FROM node:22-alpine AS build
LABEL stage=builder

# Set the working directory inside the container
WORKDIR /app

# Copy package.json and package-lock.json to leverage Docker layer caching
COPY package*.json ./

# Install all dependencies, including the development ones needed for building
RUN npm install

# Copy the rest of the application source code
COPY . .

# Run the build script defined in package.json (vite build)
# This will create the /app/build directory with all the static files.
RUN npm run build

# ---

# Stage 2: Serve the application with the Express server
# We use a fresh, lightweight Node image for the final production environment
FROM node:22-alpine AS production

WORKDIR /app

# Copy package.json and package-lock.json from the build stage
COPY --from=build /app/package*.json ./

# Install only the production dependencies (e.g., express)
# This makes the final image smaller and more secure.
RUN npm install express

# Copy the server.js file from the build stage
COPY --from=build /app/server.js .

# Copy the 'build' directory (containing the static React app) from the build stage
COPY --from=build /app/build ./build

# Expose the port the server will run on
EXPOSE 8080

# The command to start the Express server when the container launches
CMD ["node", "server.js"]

