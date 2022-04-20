<template>
  <BaseLayout>
    <div class="login">
      <h1>This is an login page</h1>
      <div><label for="username">Username: </label><input type="email" name="username" id="username"></div>
      <div><label for="password">Password: </label><input type="password" name="password" id="password"></div>
      <div><button @click="$router.push({name: 'home'})">submit</button></div>
    </div>
  </BaseLayout>
</template>