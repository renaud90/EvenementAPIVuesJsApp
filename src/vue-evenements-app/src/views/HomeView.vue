<template>
  <BaseLayout>
    <div class="home">
      <img alt="logo" src="../assets/events.png" />
      <HelloWorld
        msg="Bienvenue dans notre application qui gère les évenements à Québec"
      />
    </div>
  </BaseLayout>
</template>

<script>
// @ is an alias to /src
import HelloWorld from "@/components/HelloWorld.vue";

export default {
  name: "HomeView",
  components: {
    HelloWorld,
  },
};
</script>
