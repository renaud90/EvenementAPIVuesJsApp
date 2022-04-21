<template>
  <div class="container">
    <header>
      <slot name="header">
        <nav>
          <router-link to="/">Home</router-link> |
          <router-link to="/evenements">Evenements</router-link> |
          <router-link id="login" to="/login">Login</router-link>
        </nav>
      </slot>
    </header>
    <main>
      <slot></slot>
    </main>
    <footer id="footer">
      <slot name="footer">
        <h3>
          Ce projet a été Réalisé dans le cadre du cours dévelppement web 2 au
          cégep Limoilou.
        </h3>
      </slot>
    </footer>
  </div>
</template>
