using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wordle
{
    /// <summary>
    /// trieda, ktora obsluhuje primarne graficke prostredie hry
    /// </summary>
    public partial class Form1 : Form
    {
        private Game game;
        public Form1()
        {
            InitializeComponent();

            game = new Game();
            game.GenerateWord();

            labels_list.Add(null);
            labels_list.Add(label1);
            labels_list.Add(label2);
            labels_list.Add(label3);
            labels_list.Add(label4);
            labels_list.Add(label5);
            labels_list.Add(label6);
            labels_list.Add(label7);
            labels_list.Add(label8);
            labels_list.Add(label9);
            labels_list.Add(label10);
            labels_list.Add(label11);
            labels_list.Add(label12);
            labels_list.Add(label13);
            labels_list.Add(label14);
            labels_list.Add(label15);
            labels_list.Add(label16);
            labels_list.Add(label17);
            labels_list.Add(label18);
            labels_list.Add(label19);
            labels_list.Add(label20);
            labels_list.Add(label21);
            labels_list.Add(label22);
            labels_list.Add(label23);
            labels_list.Add(label24);
            labels_list.Add(label25);
            labels_list.Add(label26);
            labels_list.Add(label27);
            labels_list.Add(label28);
            labels_list.Add(label29);
            labels_list.Add(label30);

            buttons.Add(Keys.A, buttonA);
            buttons.Add(Keys.B, buttonB);
            buttons.Add(Keys.C, buttonC);
            buttons.Add(Keys.D, buttonD);
            buttons.Add(Keys.E, buttonE);
            buttons.Add(Keys.F, buttonF);
            buttons.Add(Keys.G, buttonG);
            buttons.Add(Keys.H, buttonH);
            buttons.Add(Keys.I, buttonI);
            buttons.Add(Keys.J, buttonJ);
            buttons.Add(Keys.K, buttonK);
            buttons.Add(Keys.L, buttonL);
            buttons.Add(Keys.M, buttonM);
            buttons.Add(Keys.N, buttonN);
            buttons.Add(Keys.O, buttonO);
            buttons.Add(Keys.P, buttonP);
            buttons.Add(Keys.Q, buttonQ);
            buttons.Add(Keys.R, buttonR);
            buttons.Add(Keys.S, buttonS);
            buttons.Add(Keys.T, buttonT);
            buttons.Add(Keys.U, buttonU);
            buttons.Add(Keys.V, buttonV);
            buttons.Add(Keys.W, buttonW);
            buttons.Add(Keys.X, buttonX);
            buttons.Add(Keys.Y, buttonY);
            buttons.Add(Keys.Z, buttonZ);
        }

        string[] colors = new string[5];
        List<Label> labels_list = new List<Label>();
        int which_label = 1;
        int which_letter = 1;
        string guessed_word = "";
        List<Button> pressed_buttons = new List<Button>();
        List<Button> used_buttons = new List<Button>();
        Dictionary<Keys,Button> buttons = new Dictionary<Keys,Button>();
        
        /// <summary>
        /// metoda pripise kliknute pismenko (z buttonu alebo klavesnice) k hadanemu slovu (zapise na prislusny label)
        /// </summary>
        /// <param name="label"> aktualny label, na ktorom sa zobrazi prave stlacene pismenko </param>
        /// <param name="button"> aktualny button (resp. klaves), ktory prave stlacame </param>
        public void ClickALetter(Label label, Button button)
        {
            if (which_letter % 6 != 0)
            {
                label.Text = button.Text;
                guessed_word = guessed_word + button.Text;
                which_label++;
                which_letter++;
                pressed_buttons.Add(button);
                used_buttons.Add(button);
            }
        }

        /// <summary>
        /// metoda, ktora sa vola pri stlaceni buttonu ENTER alebo klavesy F10
        /// vyhodnocuje hadane slovo 
        /// (zafarbuje prislusne labely a stlacene pismena na zeleno / zlto / tmavosivo podla spravnosti)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_enter_Click(object sender, EventArgs e)
        {
            if (guessed_word.Length < 5)
            {
                MessageBox.Show("Not enough letters!");
                return;
            }

            if (Game.database.Contains(guessed_word.ToLower()) == false)
            {
                MessageBox.Show($"{guessed_word} is not a valid word!");
                return;
            }

            game.Evaluate(guessed_word, colors);

            for (int i = 0; i < 5; i++)
            {
                labels_list[5 * game.which_guess + i + 1].BackColor = Color.FromName(colors[i]);
                if (pressed_buttons[i].BackColor != Color.Green)
                    pressed_buttons[i].BackColor = Color.FromName(colors[i]);
            }

            if (game.evaluated==true)
            {
                which_letter = 1;
                guessed_word = "";
                pressed_buttons.Clear();
            }

            if (game.win==true)
            {
                game.Win();
                which_letter = 6;
            }

            else
                game.CheckNoOfGuesses();
        }

        /// <summary>
        /// metody, ktore sa volaju pri klikani na buttony s pismenkami
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonA_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonS_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonF_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonG_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonH_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonJ_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonK_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonL_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonZ_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonV_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonN_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonM_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonQ_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonW_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonR_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonT_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonY_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonU_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonI_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonO_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }

        private void buttonP_Click(object sender, EventArgs e)
        {
            ClickALetter(labels_list[which_label], (Button)sender);
        }


        /// <summary>
        /// metoda, ktora sa vola pri stlaceni buttonu alebo klavesy BACKSPACE
        /// maze posledne pismenko z hadaneho slova (a teda aj z prislusneho labelu)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_delete_Click(object sender, EventArgs e)
        {
            if (guessed_word.Length > 0)
            {
                guessed_word = guessed_word.Remove(guessed_word.Length - 1);
                labels_list[which_label - 1].Text = "";
                which_letter--;
                which_label--;
                pressed_buttons.RemoveAt(pressed_buttons.Count - 1);
            }
        }

        /// <summary>
        /// metoda, ktora sa vola pri stlaceni buttonu NEW GAME
        /// spusta novu hru, vracia premenne do stavu ako na zaciatku hry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_new_game_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < which_label; i++)
            {
                labels_list[i].BackColor = Color.Gray;
                labels_list[i].Text = "";
            }

            for (int i = 0; i < used_buttons.Count; i++)
                used_buttons[i].BackColor = Color.Gray;

            guessed_word = "";
            which_label = 1;
            which_letter = 1;
            game.which_guess = 0;
            game.GenerateWord();
            game.evaluated = false;
            game.win = false;

        }

        /// <summary>
        /// metoda, ktora sa vola pri stlaceni buttonu "?"
        /// zobrazuje okno so strucnymi pravidlami hry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_instructions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HOW TO PLAY:" +
                "\nGuess the word in 6 tries." +
                "\nEach guess must be a valid 5-letter word." +
                "\nPress the button EVAL or the key F10 on your keyboard to submit your guess." +
                "\nAfter each guess, the color of the tiles will change to show how close your guess was to the word." +
                "\nGreen color means the letter is in the word and in the correct spot." +
                "\nYellow color means the letter is in the word but it the wrong spot." +
                "\nGray color means the letter is not in the word at all." +
                "\nPress the button NEW GAME to start a new game with a new word.");
        }

        /// <summary>
        /// metoda, ktora obsluhuje stlacanie klavesnice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                this.Close();
            else if (e.KeyData == Keys.F10)
                button_enter_Click(null, null);
            else if (e.KeyData == Keys.Back)
                button_delete_Click(null, null);
            else
            {
                if (buttons.ContainsKey(e.KeyData))
                    ClickALetter(labels_list[which_label], buttons[e.KeyData]);
            }
        }
    }

    /// <summary>
    /// trieda, ktora obsluhuje priebeh hry
    /// </summary>
    public class Game
    {
        
        public static HashSet<string> database = new HashSet<string>() { "aback", "abase", "abate", "abbey", "abbot", "abhor", "abide", "abled", "abode", "abort", "about", "above", "abuse", "abyss", "acorn", "acrid", "actor", "acute", "adage", "adapt", "adept", "admin", "admit", "adobe", "adopt", "adore", "adorn", "adult", "affix", "afire", "afoot", "afoul", "after", "again", "agape", "agate", "agent", "agile", "aging", "aglow", "agony", "agree", "ahead", "aider", "aisle", "alarm", "album", "alert", "algae", "alibi", "alien", "align", "alike", "alive", "allay", "alley", "allot", "allow", "alloy", "aloft", "alone", "along", "aloof", "aloud", "alpha", "altar", "alter", "amass", "amaze", "amber", "amble", "amend", "amiss", "amity", "among", "ample", "amply", "amuse", "angel", "anger", "angle", "angry", "angst", "anime", "ankle", "annex", "annoy", "annul", "anode", "antic", "anvil", "aorta", "apart", "aphid", "aping", "apnea", "apple", "apply", "apron", "aptly", "arbor", "ardor", "arena", "argue", "arise", "armor", "aroma", "arose", "array", "arrow", "arson", "artsy", "ascot", "ashen", "aside", "askew", "assay", "asset", "atoll", "atone", "attic", "audio", "audit", "augur", "aunty", "avail", "avert", "avian", "avoid", "await", "awake", "award", "aware", "awash", "awful", "awoke", "axial", "axiom", "axion", "azure", "bacon", "badge", "badly", "bagel", "baggy", "baker", "baler", "balmy", "banal", "banjo", "barge", "baron", "basal", "basic", "basil", "basin", "basis", "baste", "batch", "bathe", "baton", "batty", "bawdy", "bayou", "beach", "beady", "beard", "beast", "beech", "beefy", "befit", "began", "begat", "beget", "begin", "begun", "being", "belch", "belie", "belle", "belly", "below", "bench", "beret", "berry", "berth", "beset", "betel", "bevel", "bezel", "bible", "bicep", "biddy", "bigot", "bilge", "billy", "binge", "bingo", "biome", "birch", "birth", "bison", "bitty", "black", "blade", "blame", "bland", "blank", "blare", "blast", "blaze", "bleak", "bleat", "bleed", "bleep", "blend", "bless", "blimp", "blind", "blink", "bliss", "blitz", "bloat", "block", "bloke", "blond", "blood", "bloom", "blown", "bluer", "bluff", "blunt", "blurb", "blurt", "blush", "board", "boast", "bobby", "boney", "bongo", "bonus", "booby", "boost", "booth", "booty", "booze", "boozy", "borax", "borne", "bosom", "bossy", "botch", "bough", "boule", "bound", "bowel", "boxer", "brace", "braid", "brain", "brake", "brand", "brash", "brass", "brave", "bravo", "brawl", "brawn", "bread", "break", "breed", "briar", "bribe", "brick", "bride", "brief", "brine", "bring", "brink", "briny", "brisk", "broad", "broil", "broke", "brood", "brook", "broom", "broth", "brown", "brunt", "brush", "brute", "buddy", "budge", "buggy", "bugle", "build", "built", "bulge", "bulky", "bully", "bunch", "bunny", "burly", "burnt", "burst", "bused", "bushy", "butch", "butte", "buxom", "buyer", "bylaw", "cabal", "cabby", "cabin", "cable", "cacao", "cache", "cacti", "caddy", "cadet", "cagey", "cairn", "camel", "cameo", "canal", "candy", "canny", "canoe", "canon", "caper", "caput", "carat", "cargo", "carol", "carry", "carve", "caste", "catch", "cater", "catty", "caulk", "cause", "cavil", "cease", "cedar", "cello", "chafe", "chaff", "chain", "chair", "chalk", "champ", "chant", "chaos", "chard", "charm", "chart", "chase", "chasm", "cheap", "cheat", "check", "cheek", "cheer", "chess", "chest", "chick", "chide", "chief", "child", "chili", "chill", "chime", "china", "chirp", "chock", "choir", "choke", "chord", "chore", "chose", "chuck", "chump", "chunk", "churn", "chute", "cider", "cigar", "cinch", "circa", "civic", "/civi", "clack", "claim", "clamp", "clang", "clank", "clash", "clasp", "class", "clean", "clear", "cleat", "cleft", "clerk", "click", "cliff", "climb", "cling", "clink", "cloak", "clock", "clone", "close", "cloth", "cloud", "clout", "clove", "clown", "cluck", "clued", "clump", "clung", "coach", "coast", "cobra", "cocoa", "colon", "color", "comet", "comfy", "comic", "comma", "conch", "condo", "conic", "copse", "coral", "corer", "corny", "couch", "cough", "could", "count", "coupe", "court", "coven", "cover", "covet", "covey", "cower", "coyly", "crack", "craft", "cramp", "crane", "crank", "crash", "crass", "crate", "crave", "crawl", "craze", "crazy", "creak", "cream", "credo", "creed", "creek", "creep", "creme", "crepe", "crept", "cress", "crest", "crick", "cried", "crier", "crime", "crimp", "crisp", "croak", "crock", "crone", "crony", "crook", "cross", "croup", "crowd", "crown", "crude", "cruel", "crumb", "crump", "crush", "crust", "crypt", "cubic", "cumin", "curio", "curly", "curry", "curse", "curve", "curvy", "cutie", "cyber", "cycle", "cynic", "daddy", "daily", "dairy", "daisy", "dally", "dance", "dandy", "datum", "daunt", "dealt", "death", "debar", "debit", "debug", "debut", "decal", "decay", "decor", "decoy", "decry", "defer", "deign", "deity", "delay", "delta", "delve", "demon", "demur", "denim", "dense", "depot", "depth", "derby", "deter", "detox", "deuce", "devil", "diary", "dicey", "digit", "dilly", "dimly", "diner", "dingo", "dingy", "diode", "dirge", "dirty", "disco", "ditch", "ditto", "ditty", "diver", "dizzy", "dodge", "dodgy", "dogma", "doing", "dolly", "donor", "donut", "dopey", "doubt", "dough", "dowdy", "dowel", "downy", "dowry", "dozen", "draft", "drain", "drake", "drama", "drank", "drape", "drawl", "drawn", "dread", "dream", "dress", "dried", "drier", "drift", "drill", "drink", "drive", "droit", "droll", "drone", "drool", "droop", "dross", "drove", "drown", "druid", "drunk", "dryer", "dryly", "duchy", "dully", "dummy", "dumpy", "dunce", "dusky", "dusty", "dutch", "duvet", "dwarf", "dwell", "dwelt", "dying", "eagle", "early", "earth", "easel", "eaten", "eater", "ebony", "eclat", "edict", "edify", "eerie", "egret", "eight", "eject", "eking", "elate", "elbow", "elder", "elect", "elegy", "elfin", "elide", "elite", "elope", "elude", "email", "embed", "ember", "emcee", "empty", "enact", "endow", "enema", "enemy", "enjoy", "ennui", "ensue", "enter", "entry", "envoy", "epoch", "epoxy", "equal", "equip", "erase", "erect", "erode", "error", "erupt", "essay", "ester", "ether", "ethic", "ethos", "etude", "evade", "event", "every", "evict", "evoke", "exact", "exalt", "excel", "exert", "exile", "exist", "expel", "extol", "extra", "exult", "eying", "fable", "facet", "faint", "fairy", "faith", "false", "fancy", "fanny", "farce", "fatal", "fatty", "fault", "fauna", "favor", "feast", "fecal", "feign", "fella", "felon", "femme", "femur", "fence", "feral", "ferry", "fetal", "fetch", "fetid", "fetus", "fever", "fewer", "fiber", "ficus", "field", "fiend", "fiery", "fifth", "fifty", "fight", "filer", "filet", "filly", "filmy", "filth", "final", "finch", "finer", "first", "fishy", "fixer", "fizzy", "fjord", "flack", "flail", "flair", "flake", "flaky", "flame", "flank", "flare", "flash", "flask", "fleck", "fleet", "flesh", "flick", "flier", "fling", "flint", "flirt", "float", "flock", "flood", "floor", "flora", "floss", "flour", "flout", "flown", "fluff", "fluid", "fluke", "flume", "flung", "flunk", "flush", "flute", "flyer", "foamy", "focal", "focus", "foggy", "foist", "folio", "folly", "foray", "force", "forge", "forgo", "forte", "forth", "forty", "forum", "found", "foyer", "frail", "frame", "frank", "fraud", "freak", "freed", "freer", "fresh", "friar", "fried", "frill", "frisk", "fritz", "frock", "frond", "front", "frost", "froth", "frown", "froze", "fruit", "fudge", "fugue", "fully", "fungi", "funky", "funny", "furor", "furry", "fussy", "fuzzy", "gaffe", "gaily", "gamer", "gamma", "gamut", "gassy", "gaudy", "gauge", "gaunt", "gauze", "gavel", "gawky", "gayer", "gayly", "gazer", "gecko", "geeky", "geese", "genie", "genre", "ghost", "ghoul", "giant", "giddy", "gipsy", "girly", "girth", "given", "giver", "glade", "gland", "glare", "glass", "glaze", "gleam", "glean", "glide", "glint", "gloat", "globe", "gloom", "glory", "gloss", "glove", "glyph", "gnash", "gnome", "godly", "going", "golem", "golly", "gonad", "goner", "goody", "gooey", "goofy", "goose", "gorge", "gouge", "gourd", "grace", "grade", "graft", "grail", "grain", "grand", "grant", "grape", "graph", "grasp", "grass", "grate", "grave", "gravy", "graze", "great", "greed", "green", "greet", "grief", "grill", "grime", "grimy", "grind", "gripe", "groan", "groin", "groom", "grope", "gross", "group", "grout", "grove", "growl", "grown", "gruel", "gruff", "grunt", "guard", "guava", "guess", "guest", "guide", "guild", "guile", "guilt", "guise", "gulch", "gully", "gumbo", "gummy", "guppy", "gusto", "gusty", "gypsy", "habit", "hairy", "halve", "handy", "happy", "hardy", "harem", "harpy", "harry", "harsh", "haste", "hasty", "hatch", "hater", "haunt", "haute", "haven", "havoc", "hazel", "heady", "heard", "heart", "heath", "heave", "heavy", "hedge", "hefty", "heist", "helix", "hello", "hence", "heron", "hilly", "hinge", "hippo", "hippy", "hitch", "hoard", "hobby", "hoist", "holly", "homer", "honey", "honor", "horde", "horny", "horse", "hotel", "hotly", "hound", "house", "hovel", "hover", "howdy", "human", "humid", "humor", "humph", "humus", "hunch", "hunky", "hurry", "husky", "hussy", "hutch", "hydro", "hyena", "hymen", "hyper", "icily", "icing", "ideal", "idiom", "idiot", "idler", "idyll", "igloo", "iliac", "image", "imbue", "impel", "imply", "inane", "inbox", "incur", "index", "inept", "inert", "infer", "ingot", "inlay", "inlet", "inner", "input", "inter", "intro", "ionic", "irate", "irony", "islet", "issue", "itchy", "ivory", "jaunt", "jazzy", "jelly", "jerky", "jetty", "jewel", "jiffy", "joint", "joist", "joker", "jolly", "joust", "judge", "juice", "juicy", "jumbo", "jumpy", "junta", "junto", "juror", "kappa", "karma", "kayak", "kebab", "khaki", "kinky", "kiosk", "kitty", "knack", "knave", "knead", "kneed", "kneel", "knelt", "knife", "knock", "knoll", "known", "koala", "krill", "label", "labor", "laden", "ladle", "lager", "lance", "lanky", "lapel", "lapse", "large", "larva", "lasso", "latch", "later", "lathe", "latte", "laugh", "layer", "leach", "leafy", "leaky", "leant", "leapt", "learn", "lease", "leash", "least", "leave", "ledge", "leech", "leery", "lefty", "legal", "leggy", "lemon", "lemur", "leper", "level", "lever", "libel", "liege", "light", "liken", "lilac", "limbo", "limit", "linen", "liner", "lingo", "lipid", "lithe", "liver", "livid", "llama", "loamy", "loath", "lobby", "local", "locus", "lodge", "lofty", "logic", "login", "loopy", "loose", "lorry", "loser", "louse", "lousy", "lover", "lower", "lowly", "loyal", "lucid", "lucky", "lumen", "lumpy", "lunar", "lunch", "lunge", "lupus", "lurch", "lurid", "lusty", "lying", "lymph", "lyric", "macaw", "macho", "macro", "madam", "madly", "mafia", "magic", "magma", "maize", "major", "maker", "mambo", "mamma", "mammy", "manga", "mange", "mango", "mangy", "mania", "manic", "manly", "manor", "maple", "march", "marry", "marsh", "mason", "masse", "match", "matey", "mauve", "maxim", "maybe", "mayor", "mealy", "meant", "meaty", "mecca", "medal", "media", "medic", "melee", "melon", "mercy", "merge", "merit", "merry", "metal", "meter", "metro", "micro", "midge", "midst", "might", "milky", "mimic", "mince", "miner", "minim", "minor", "minty", "minus", "mirth", "miser", "missy", "mocha", "modal", "model", "modem", "mogul", "moist", "molar", "moldy", "money", "month", "moody", "moose", "moral", "moron", "morph", "mossy", "motel", "motif", "motor", "motto", "moult", "mound", "mount", "mourn", "mouse", "mouth", "mover", "movie", "mower", "mucky", "mucus", "muddy", "mulch", "mummy", "munch", "mural", "murky", "mushy", "music", "musky", "musty", "myrrh", "nadir", "naive", "nanny", "nasal", "nasty", "natal", "naval", "navel", "needy", "neigh", "nerdy", "nerve", "never", "newer", "newly", "nicer", "niche", "niece", "night", "ninja", "ninny", "ninth", "noble", "nobly", "noise", "noisy", "nomad", "noose", "north", "nosey", "notch", "novel", "nudge", "nurse", "nutty", "nylon", "nymph", "oaken", "obese", "occur", "ocean", "octal", "octet", "odder", "oddly", "offal", "offer", "often", "olden", "older", "olive", "ombre", "omega", "onion", "onset", "opera", "opine", "opium", "optic", "orbit", "order", "organ", "other", "otter", "ought", "ounce", "outdo", "outer", "outgo", "ovary", "ovate", "overt", "ovine", "ovoid", "owing", "owner", "oxide", "ozone", "paddy", "pagan", "paint", "paler", "palsy", "panel", "panic", "pansy", "papal", "paper", "parer", "parka", "parry", "parse", "party", "pasta", "paste", "pasty", "patch", "patio", "patsy", "patty", "pause", "payee", "payer", "peace", "peach", "pearl", "pecan", "pedal", "penal", "pence", "penne", "penny", "perch", "peril", "perky", "pesky", "pesto", "petal", "petty", "phase", "phone", "phony", "photo", "piano", "picky", "piece", "piety", "piggy", "pilot", "pinch", "piney", "pinky", "pinto", "piper", "pique", "pitch", "pithy", "pivot", "pixel", "pixie", "pizza", "place", "plaid", "plain", "plait", "plane", "plank", "plant", "plate", "plaza", "plead", "pleat", "plied", "plier", "pluck", "plumb", "plume", "plump", "plunk", "plush", "poesy", "point", "poise", "poker", "polar", "polka", "polyp", "pooch", "poppy", "porch", "poser", "posit", "posse", "pouch", "pound", "pouty", "power", "prank", "prawn", "preen", "press", "price", "prick", "pride", "pried", "prime", "primo", "print", "prior", "prism", "privy", "prize", "probe", "prone", "prong", "proof", "prose", "proud", "prove", "prowl", "proxy", "prude", "prune", "psalm", "pubic", "pudgy", "puffy", "pulpy", "pulse", "punch", "pupil", "puppy", "puree", "purer", "purge", "purse", "pushy", "putty", "pygmy", "quack", "quail", "quake", "qualm", "quark", "quart", "quash", "quasi", "queen", "queer", "quell", "query", "quest", "queue", "quick", "quiet", "quill", "quilt", "quirk", "quite", "quota", "quote", "quoth", "rabbi", "rabid", "racer", "radar", "radii", "radio", "rainy", "raise", "rajah", "rally", "ralph", "ramen", "ranch", "randy", "range", "rapid", "rarer", "raspy", "ratio", "ratty", "raven", "rayon", "razor", "reach", "react", "ready", "realm", "rearm", "rebar", "rebel", "rebus", "rebut", "recap", "recur", "recut", "reedy", "refer", "refit", "regal", "rehab", "reign", "relax", "relay", "relic", "remit", "renal", "renew", "repay", "repel", "reply", "rerun", "reset", "resin", "retch", "retro", "retry", "reuse", "revel", "revue", "rhino", "rhyme", "rider", "ridge", "rifle", "right", "rigid", "rigor", "rinse", "ripen", "riper", "risen", "riser", "risky", "rival", "river", "rivet", "roach", "roast", "robin", "robot", "rocky", "rodeo", "roger", "rogue", "roomy", "roost", "rotor", "rouge", "rough", "round", "rouse", "route", "rover", "rowdy", "rower", "royal", "ruddy", "ruder", "rugby", "ruler", "rumba", "rumor", "rupee", "rural", "rusty", "sadly", "safer", "saint", "salad", "sally", "salon", "salsa", "salty", "salve", "salvo", "sandy", "saner", "sappy", "sassy", "satin", "satyr", "sauce", "saucy", "sauna", "saute", "savor", "savoy", "savvy", "scald", "scale", "scalp", "scaly", "scamp", "scant", "scare", "scarf", "scary", "scene", "scent", "scion", "scoff", "scold", "scone", "scoop", "scope", "score", "scorn", "scour", "scout", "scowl", "scram", "scrap", "scree", "screw", "scrub", "scrum", "scuba", "sedan", "seedy", "segue", "seize", "semen", "sense", "sepia", "serif", "serum", "serve", "setup", "seven", "sever", "sewer", "shack", "shade", "shady", "shaft", "shake", "shaky", "shale", "shall", "shalt", "shame", "shank", "shape", "shard", "share", "shark", "sharp", "shave", "shawl", "shear", "sheen", "sheep", "sheer", "sheet", "sheik", "shelf", "shell", "shied", "shift", "shine", "shiny", "shire", "shirk", "shirt", "shoal", "shock", "shone", "shook", "shoot", "shore", "shorn", "short", "shout", "shove", "shown", "showy", "shrew", "shrub", "shrug", "shuck", "shunt", "shush", "shyly", "siege", "sieve", "sight", "sigma", "silky", "silly", "since", "sinew", "singe", "siren", "sissy", "sixth", "sixty", "skate", "skier", "skiff", "skill", "skimp", "skirt", "skulk", "skull", "skunk", "slack", "slain", "slang", "slant", "slash", "slate", "sleek", "sleep", "sleet", "slept", "slice", "slick", "slide", "slime", "slimy", "sling", "slink", "sloop", "slope", "slosh", "sloth", "slump", "slung", "slunk", "slurp", "slush", "slyly", "smack", "small", "smart", "smash", "smear", "smell", "smelt", "smile", "smirk", "smite", "smith", "smock", "smoke", "smoky", "smote", "snack", "snail", "snake", "snaky", "snare", "snarl", "sneak", "sneer", "snide", "sniff", "snipe", "snoop", "snore", "snort", "snout", "snowy", "snuck", "snuff", "soapy", "sober", "soggy", "solar", "solid", "solve", "sonar", "sonic", "sooth", "sooty", "sorry", "sound", "south", "sower", "space", "spade", "spank", "spare", "spark", "spasm", "spawn", "speak", "spear", "speck", "speed", "spell", "spelt", "spend", "spent", "sperm", "spice", "spicy", "spied", "spiel", "spike", "spiky", "spill", "spilt", "spine", "spiny", "spire", "spite", "splat", "split", "spoil", "spoke", "spoof", "spook", "spool", "spoon", "spore", "sport", "spout", "spray", "spree", "sprig", "spunk", "spurn", "spurt", "squad", "squat", "squib", "stack", "staff", "stage", "staid", "stain", "stair", "stake", "stale", "stalk", "stall", "stamp", "stand", "stank", "stare", "stark", "start", "stash", "state", "stave", "stead", "steak", "steal", "steam", "steed", "steel", "steep", "steer", "stein", "stern", "stick", "stiff", "still", "stilt", "sting", "stink", "stint", "stock", "stoic", "stoke", "stole", "stomp", "stone", "stony", "stood", "stool", "stoop", "store", "stork", "storm", "story", "stout", "stove", "strap", "straw", "stray", "strip", "strut", "stuck", "study", "stuff", "stump", "stung", "stunk", "stunt", "style", "suave", "sugar", "suing", "suite", "sulky", "sully", "sumac", "sunny", "super", "surer", "surge", "surly", "sushi", "swami", "swamp", "swarm", "swash", "swath", "swear", "sweat", "sweep", "sweet", "swell", "swept", "swift", "swill", "swine", "swing", "swirl", "swish", "swoon", "swoop", "sword", "swore", "sworn", "swung", "synod", "syrup", "tabby", "table", "taboo", "tacit", "tacky", "taffy", "taint", "taken", "taker", "tally", "talon", "tamer", "tango", "tangy", "taper", "tapir", "tardy", "tarot", "taste", "tasty", "tatty", "taunt", "tawny", "teach", "teary", "tease", "teddy", "teeth", "tempo", "tenet", "tenor", "tense", "tenth", "tepee", "tepid", "terra", "terse", "testy", "thank", "theft", "their", "theme", "there", "these", "theta", "thick", "thief", "thigh", "thing", "think", "third", "thong", "thorn", "those", "three", "threw", "throb", "throw", "thrum", "thumb", "thump", "thyme", "tiara", "tibia", "tidal", "tiger", "tight", "tilde", "timer", "timid", "tipsy", "titan", "tithe", "title", "toast", "today", "toddy", "token", "tonal", "tonga", "tonic", "tooth", "topaz", "topic", "torch", "torso", "torus", "total", "totem", "touch", "tough", "towel", "tower", "toxic", "toxin", "trace", "track", "tract", "trade", "trail", "train", "trait", "tramp", "trash", "trawl", "tread", "treat", "trend", "triad", "trial", "tribe", "trice", "trick", "tried", "tripe", "trite", "troll", "troop", "trope", "trout", "trove", "truce", "truck", "truer", "truly", "trump", "trunk", "truss", "trust", "truth", "tryst", "tubal", "tuber", "tulip", "tulle", "tumor", "tunic", "turbo", "tutor", "twang", "tweak", "tweed", "tweet", "twice", "twine", "twirl", "twist", "twixt", "tying", "udder", "ulcer", "ultra", "umbra", "uncle", "uncut", "under", "undid", "undue", "unfed", "unfit", "unify", "union", "unite", "unity", "unlit", "unmet", "unset", "untie", "until", "unwed", "unzip", "upper", "upset", "urban", "urine", "usage", "usher", "using", "usual", "usurp", "utile", "utter", "vague", "valet", "valid", "valor", "value", "valve", "vapid", "vapor", "vault", "vaunt", "vegan", "venom", "venue", "verge", "verse", "verso", "verve", "vicar", "video", "vigil", "vigor", "villa", "vinyl", "viola", "viper", "viral", "virus", "visit", "visor", "vista", "vital", "vivid", "vixen", "vocal", "vodka", "vogue", "voice", "voila", "vomit", "voter", "vouch", "vowel", "vying", "wacky", "wafer", "wager", "wagon", "waist", "waive", "waltz", "warty", "waste", "watch", "water", "waver", "waxen", "weary", "weave", "wedge", "weedy", "weigh", "weird", "welch", "welsh", "whack", "whale", "wharf", "wheat", "wheel", "whelp", "where", "which", "whiff", "while", "whine", "whiny", "whirl", "whisk", "white", "whole", "whoop", "whose", "widen", "wider", "widow", "width", "wield", "wight", "willy", "wimpy", "wince", "winch", "windy", "wiser", "wispy", "witch", "witty", "woken", "woman", "women", "woody", "wooer", "wooly", "woozy", "wordy", "world", "worry", "worse", "worst", "worth", "would", "wound", "woven", "wrack", "wrath", "wreak", "wreck", "wrest", "wring", "wrist", "write", "wrong", "wrote", "wrung", "wryly", "yacht", "yearn", "yeast", "yield", "young", "youth", "zebra", "zesty", "zonal" };
        static Random random = new Random();
        
        string the_word;
        public int which_guess = 0;

        public bool win = false;
        public bool evaluated = false;

        /// <summary>
        /// metoda, ktora generuje nahodne slovo z databazy slov
        /// </summary>
        public void GenerateWord()
        {
            the_word = database.ElementAt(random.Next(database.Count));
        }

        /// <summary>
        /// metoda, ktora vyhodnocuje zadane slovo
        /// priraduje kazdemu pismenku zadaneho slova prislusnu farbu podla spravnosti
        /// </summary>
        /// <param name="entered_word"> zadavane (=hadane) slovo </param>
        /// <param name="colors"> zoznam farieb prisluchajucich jednotlivym pismenkam </param>
        /// <returns> vracia colors, teda zoznam faribe prisluchajucich jednolivym pismenkam zadaneho slova </returns>
        public string[] Evaluate(string entered_word, string[] colors)
        {
            entered_word = entered_word.ToLower();

            colors[0] = "WindowFrame";
            colors[1] = "WindowFrame";
            colors[2] = "WindowFrame";
            colors[3] = "WindowFrame";
            colors[4] = "WindowFrame";

            if (entered_word == the_word)
                {
                    for (int i = 0; i < 5; i++)
                        colors[i] = "Green";
                    win = true;
                }

            else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (the_word[i] == entered_word[i])
                            colors[i] = "Green";
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        if (colors[i] != "Green")
                            if (the_word.Contains(entered_word[i]))
                                colors[i] = "Goldenrod";
                    }

                    evaluated = true;

                }
            
            return colors;
        }

        /// <summary>
        /// metoda, ktora kontroluje, kolky pokus v poradi prave zadavame
        /// </summary>
        public void CheckNoOfGuesses()
        {
            if (which_guess == 5)
                MessageBox.Show($"You lost! The word was {the_word}.");
            else
                which_guess++;
        }

        /// <summary>
        /// metoda, ktora ohlasuje vyhru v novom okne
        /// </summary>
        public void Win()
        {
            MessageBox.Show("You won!");
        }

    }

}
