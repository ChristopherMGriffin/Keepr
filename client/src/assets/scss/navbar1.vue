<template>
  <nav class="navbar sticky p-0">
    <div class="col-sm-1 col-md-2 mr-4">
      <router-link class="navbar-brand" :to="{ path: '/' }">
        <div class="d-flex flex-column align-items-center m-0 p-0">
          <img
            alt="logo"
            src="../assets/img/klogo.png"
            height="45"
          />
        </div>
      </router-link>
    </div>
    <div class="col-md-7 col-sm-3 col-xs-2 d-flex align-items-center">
      <div class="input-group mt-2">
        <!-- <div class="input-group-prepend">
              <span class="input-group-text" id="inputGroup-sizing-default">Default</span>
            </div> -->
        <!-- <input type="text" class="form-control-sm mb-2" aria-label="Default" aria-describedby="inputGroup-sizing-default"> -->
        <input type="text" class="form-control mb-2" aria-label="Default" aria-describedby="inputGroup-sizing-default">
      </div>
    </div>
    <div class="col-sm-1 col-md-2 p d-flex justify-content-end">
      <button
        class="btn text-uppercase border-dark"
        @click="login"
      >
        Log In
      </button>
      <button
        class="btn text-uppercase border-dark"
        @click="logout"
      >
        Log Out
      </button>

    </div>
  </nav>
</template>

<script>
import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed, reactive } from 'vue'
export default {
  name: 'Navbar',
  setup() {
    const state = reactive({
      dropOpen: false
    })
    return {
      state,
      user: computed(() => AppState.user),
      async login() {
        AuthService.loginWithPopup()
      },

      async logout() {
        await AuthService.logout({ returnTo: window.location.origin })
      }
    }
  }
}
</script>

<style scoped>
.dropdown-menu {
  user-select: none;
  display: block;
  transform: scale(0);
  transition: all 0.15s linear;
}
.dropdown-menu.show {
  transform: scale(1);
}
.hoverable {
  cursor: pointer;
}
a:hover {
  text-decoration: none;
}
.nav-link{
  text-transform: uppercase;
}
.nav-item .nav-link.router-link-exact-active{
  color: var(--primary);
}
.navbar {
  background-color:#97bdb2 ;
}
</style>
