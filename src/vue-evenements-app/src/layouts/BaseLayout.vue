<template>
  <div class="container">
    <div class="content">
      <header>
        <slot name="header">
          <nav>
            <router-link to="/">Home</router-link> |
            <router-link to="/evenements">Evenements</router-link> |
            <router-link id="login" to="/login">Connexion/profil</router-link>
          </nav>
        </slot>
      </header>
      <main>
        <slot></slot>
      </main>
    </div>
    <footer id="footer">
      <slot name="footer">
        <h3 id="footer-message">
          Ce projet a été réalisé dans le cadre du cours dévelppement web 2 au
          cégep Limoilou.
        </h3>
      </slot>
    </footer>
  </div>
</template>

<style>
html, body, #app, .container {
  height: 100%;
  margin: 0;
}

.container{
  display:flex;
  flex-direction: column;
}

.content{
  flex: 1 0 auto;
}

#footer{
  flex-shrink: 0;
  background-color: aquamarine;
}

#footer-message{
  padding-top:10px;
}
</style>
