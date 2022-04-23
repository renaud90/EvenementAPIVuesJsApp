<template>
  <BaseLayout>
    <div class="login">
      <h1>Profil utilisateur</h1>
      <div :class="mainOidc.isAuthenticated ? '' : 'invisible'">Informations: {{mainOidc.userProfile.name}}</div>
      <h4 :class="mainOidc.isAuthenticated ? '' : 'invisible'" id="deconnexion" @click="deconnexion()">Me déconnecter</h4>
    </div>
  </BaseLayout>
</template>

<script>
  import mainOidc from '../api/authClient.js'
  export default {
    name: "LoginView",
    data(){
      return {
        mainOidc: mainOidc
      }
    },
    methods:{
      deconnexion(){
        mainOidc.signOut();
      }
    }
  };
  
</script>

<style>
  #deconnexion{
    text-decoration: underline;
    cursor: pointer;
  }
  .invisible{
    visibility: hidden;
  }
</style>
