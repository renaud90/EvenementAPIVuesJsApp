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
                dafult footer content
            </slot>
        </footer>
    </div>
</template>